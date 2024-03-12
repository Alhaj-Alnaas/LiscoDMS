using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Runtime.InteropServices;
using WIA;
using System.Windows.Forms;

namespace ACS.Archives
{
    class WIAScanner
    {
        const string wiaFormatBMP = "{B96B3CAB-0728-11D3-9D7B-0000F81EF32E}";
        class WIA_DPS_DOCUMENT_HANDLING_SELECT
        {
            public const uint FEEDER = 0x00000001;
            public const uint FLATBED = 0x00000002;

        }
        
        class WIA_DPS_DOCUMENT_HANDLING_STATUS
        {
            public const uint FEED_READY = 0x00000001;
        }
        class WIA_PROPERTIES
        {
            public const uint WIA_RESERVED_FOR_NEW_PROPS = 1024;
            public const uint WIA_DIP_FIRST = 2;
            public const uint WIA_DPA_FIRST = WIA_DIP_FIRST + WIA_RESERVED_FOR_NEW_PROPS;
            public const uint WIA_DPC_FIRST = WIA_DPA_FIRST + WIA_RESERVED_FOR_NEW_PROPS;
            //
            // Scanner only device properties (DPS)
            //
            public const uint WIA_DPS_FIRST = WIA_DPC_FIRST + WIA_RESERVED_FOR_NEW_PROPS;
            public const uint WIA_DPS_DOCUMENT_HANDLING_STATUS = WIA_DPS_FIRST + 13;
            public const uint WIA_DPS_DOCUMENT_HANDLING_SELECT = WIA_DPS_FIRST + 14;
        }
        /// <summary>
        /// Use scanner to scan an image (with user selecting the scanner from a dialog).
        /// </summary>
        /// <returns>Scanned images.</returns>
        public static List<Image> Scan()
        {
            WIA.ICommonDialog dialog = new WIA.CommonDialog();
            WIA.Device device = dialog.ShowSelectDevice(WIA.WiaDeviceType.UnspecifiedDeviceType, true, false);
            if (device != null)
            {
                return Scan(device.DeviceID);
            }
            else
            {
                throw new Exception("You must select a device for scanning.");
            }
        }

        /// <summary>
        /// Use scanner to scan an image (scanner is selected by its unique id).
        /// </summary>
        /// <param name="scannerName"></param>
        /// <returns>Scanned images.</returns>
        public static List<Image> Scan(string scannerId)
        {
            List<Image> images = new List<Image>();

            // select the correct scanner using the provided scannerId parameter
            WIA.DeviceManager manager = new WIA.DeviceManager();
            WIA.Device device = null;
            foreach (WIA.DeviceInfo info in manager.DeviceInfos)
            {
                if (info.DeviceID == scannerId)
                {
                    // connect to scanner
                    device = info.Connect();
                    break;
                }
            }
            // device was not found
            if (device == null)
            {
                // enumerate available devices
                string availableDevices = "";
                foreach (WIA.DeviceInfo info in manager.DeviceInfos)
                {
                    availableDevices += info.DeviceID + "\n";
                }

                // show error with available devices
                throw new Exception("The device with provided ID could not be found. Available Devices:\n" + availableDevices);
            }

            WIA.Item item = null;
            WIA.CommonDialog dialog = new WIA.CommonDialog();
            WIA.Items items = dialog.ShowSelectItems(device);
            if (items == null)
                return images;

            item = items[1];

            bool hasMorePages = true;
            while (hasMorePages)
            {
                try
                {
                    // scan image
                    WIA.ICommonDialog wiaCommonDialog = new WIA.CommonDialog();
                    WIA.ImageFile image = (WIA.ImageFile)wiaCommonDialog.ShowTransfer(item, wiaFormatBMP, false);

                     //save to temp file

                    //var uniqeFilename = Guid.NewGuid().ToString();
                    //string FilePath = @"D:\ASC Project\ACS.Archives\TempFiles\";
                    //string FileName = Path.Combine(FilePath, uniqeFilename + ".Jpeg");

                    string FileName = Path.GetTempFileName();
                    File.Delete(FileName);
                    image.SaveFile(FileName);
                    try
                    {
                        Marshal.FinalReleaseComObject(image);
                    }
                    finally
                    {
                        image = null;
                    }
                    // add file to output list
                    images.Add(Image.FromFile(FileName));
                }
                catch (Exception ex) //ex.Message "0x80210003" means no documents found in feeder
                {
                    if (ex.Message.Contains("0x80210015")) MessageBox.Show("Could not connect to scanner", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (ex.Message.Contains("0x80210006")) MessageBox.Show("Device is busy", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); //where I get exception on second page each time
                    else if (ex.Message.Contains("0x80210003"))
                        goto last;
                    /*MessageBox.Show("No documents found in document feeder", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)*/
                    
                    else MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    
                }
                finally
                {
                   
                        //determine if there are any more pages waiting
                        WIA.Property documentHandlingSelect = null;
                        WIA.Property documentHandlingStatus = null;
                        foreach (WIA.Property prop in device.Properties)
                        {
                            if (prop.PropertyID == WIA_PROPERTIES.WIA_DPS_DOCUMENT_HANDLING_SELECT)
                                documentHandlingSelect = prop;
                            if (prop.PropertyID == WIA_PROPERTIES.WIA_DPS_DOCUMENT_HANDLING_STATUS)
                                documentHandlingStatus = prop;
                        }
                        // assume there are no more pages
                        hasMorePages = false;
                        // may not exist on flatbed scanner but required for feeder
                        if (documentHandlingSelect != null)
                        {
                            // check for document feeder
                            if ((Convert.ToUInt32(documentHandlingSelect.get_Value()) & WIA_DPS_DOCUMENT_HANDLING_SELECT.FEEDER) != 0)
                            {
                                hasMorePages = ((Convert.ToUInt32(documentHandlingStatus.get_Value()) & WIA_DPS_DOCUMENT_HANDLING_STATUS.FEED_READY) != 0);
                            }
                        }

                }
            }
        last: return images;

            
        }

        /// <summary>
        /// Gets the list of available WIA devices.
        /// </summary>
        /// <returns></returns>
        public static List<string> GetDevices()
        {
            List<string> devices = new List<string>();
            WIA.DeviceManager manager = new WIA.DeviceManager();
            foreach (WIA.DeviceInfo info in manager.DeviceInfos)
            {
                devices.Add(info.DeviceID);
            }
            return devices;
        }
    }
}
