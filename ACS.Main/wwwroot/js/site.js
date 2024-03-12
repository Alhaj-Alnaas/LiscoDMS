/*const { forEach } = require("lodash");*/

function validateForwardForm() {
    var body = document.getElementById('body_f').value;
    var contactsArr = document.getElementById('UsersList_f');
    var uploadObj = document.getElementById("UploadFiles").ej2_instances[0];
    var filesNumber = uploadObj.filesData.length;

    var x = 0;
    for (var option of contactsArr.options) {
        if (option.selected) {
            x++;
        }
    }

    if (x == 0 || ((body == "" || body == null) && filesNumber == 0)) {
        alert("أكمل البيانات من فضلك");
        return false;
    }
}

function validateNewMessageForm() {
    //var body = document.getElementById('body').ej2_instances[0].value;
    var title = document.getElementById('title').value;
    var contactsArr = document.getElementById('UsersList');
    var uploadObj = document.getElementById("UploadFiles").ej2_instances[0];
    var filesNumber = uploadObj.filesData.length;
    var x = 0;
    for (var option of contactsArr.options) {
        if (option.selected) {
            x++;
            break;
        }
    }

    if (x == 0 || title == "" || ((body == "" || body == null) && filesNumber == 0)) {
        alert("أكمل البيانات من فضلك");
        return false;
    }
}

function validateGeneralMessageForm() {
    var body = document.getElementById('body').ej2_instances[0].value;
    var title = document.getElementById('title').value;
    var uploadObj = document.getElementById("UploadFiles").ej2_instances[0];
    var filesNumber = uploadObj.filesData.length;

    if (title == "" || ((body == "" || body == null) && filesNumber == 0)) {
        alert("أكمل البيانات من فضلك");
        return false;
    }
}

function selectTextOrCopy(Text) {
    if (Text == 'True') {
        var uploadObj = document.getElementById("UploadFiles").ej2_instances[0];
        uploadObj.clearAll();
    }
    else if (Text == 'False') {
        var body = document.getElementById('body').ej2_instances[0];
        body.value = '';
    }
}

function save(newDraft) {
    var bodyValue;
    if (newDraft == 'True') {
        if (validateGeneralMessageForm() == false)
            return false;
        bodyValue = document.getElementById('body').ej2_instances[0].value;
    }
    else {
        var withFile = document.getElementById('withFile').value;
        if (withFile == 'true')
            bodyValue = "";
        else
            bodyValue = document.getElementById('body').ej2_instances[0].value;
    }
    var messageId = document.getElementById('messageId');
    var title = document.getElementById('title');
    //var contactsArr = document.getElementById('UsersList');
    var uploadObj = document.getElementById("UploadFiles").ej2_instances[0];
    var uploadObjTemp = document.getElementById("UploadTempFiles").ej2_instances[0];
    var senderResponsibilityCode = document.getElementById('senderResponsibilityCode');
    //var recipints = [];
    var files = [];

    //for (var option of contactsArr.options) {
    //    if (option.selected) {
    //        recipints.push({ RecipintId: option.value });
    //    }
    //}

    var respCode;
    if (senderResponsibilityCode == null)
        respCode = null;
    else
        respCode = senderResponsibilityCode.value;

    var draftId;
    if (messageId == null)
        draftId = null;
    else
        draftId = messageId.value;

    if (uploadObj != null) {
        for (let i = 0; i < uploadObj.filesData.length; i++) {
            var fileSize = uploadObj.filesData[i].size;
            if (fileSize < 5000000) {
                var newGuid = createGuid();
                var fileName = uploadObj.filesData[i].name;
                var extension = getFileExtension(fileName);
                if (extension.toLowerCase() == 'pdf' || extension.toLowerCase() == 'jpg' || extension.toLowerCase() == 'jpeg') { // || extension.toLowerCase() == 'jpg' || extension.toLowerCase() == 'jpeg'
                    files.push({ Id: newGuid, Name: fileName, Extention: extension.toLowerCase(), Size: fileSize });
                    uploadObj.filesData[i].name = newGuid + '.' + extension.toLowerCase();
                }
            }
        }
    }

    if (uploadObjTemp != null) {
        for (let i = 0; i < uploadObjTemp.filesData.length; i++) {
            var fileSize = uploadObjTemp.filesData[i].size;
            if (fileSize < 50000000) {
                var newGuid = createGuid();
                var fileName = uploadObjTemp.filesData[i].name;
                var extension = getFileExtension(fileName);
                files.push({ Id: newGuid, Name: fileName, Extention: extension.toLowerCase(), Size: fileSize, IsTemp: true });
                uploadObjTemp.filesData[i].name = newGuid + '.' + extension.toLowerCase();
            }
        }
    }
    if (newDraft == 'True') {
        var message = JSON.stringify(
            {
                Body: bodyValue,
                Title: title.value,
                ResponsibilityCode: respCode,
                Documents: files
                //Packages: recipints,
            }
        );
    }
    else {
        var message = JSON.stringify(
            {
                Id: draftId,
                Body: bodyValue,
                Title: title.value,
                ResponsibilityCode: respCode,
                Documents: files
                //Packages: recipints,
            }
        );
    }

    const Http = new XMLHttpRequest();
    Http.onreadystatechange = function () { // listen for state changes
        if (Http.readyState == 4 && Http.status == 200) { // when completed we can move away
            alert("تم الحفظ بنجاح");
            window.location = "/Messages/Inbox";
        }
    }

    if (newDraft == 'True') {
        url = '/Messages/NewDraft';
    }
    else {
        url = '/Messages/SaveDraft';
    }
    uploadObj.upload(uploadObj.getFilesData());
    uploadObjTemp.upload(uploadObjTemp.getFilesData());

    setTimeout(function () {
        Http.open("POST", url);
        Http.setRequestHeader('Content-Type', 'application/json');
        Http.send(message);
    }, 5000);
};

function saveFromSubUser(newDraft) {
    if (validateGeneralMessageForm() == false)
        return false;
    var messageId = document.getElementById('messageId');
    var body = document.getElementById('body').ej2_instances[0];
    var title = document.getElementById('title');
    var senderResponsibilityCode = document.getElementById('senderResponsibilityCode');
    var uploadObj = document.getElementById("UploadFiles").ej2_instances[0];
    var uploadObjTemp = document.getElementById("UploadTempFiles").ej2_instances[0];
    var files = [];

    var respCode;
    if (senderResponsibilityCode == null)
        respCode = null;
    else
        respCode = senderResponsibilityCode.value;

    var draftId;
    if (messageId == null)
        draftId = null;
    else
        draftId = messageId.value;

    if (uploadObj != null) {
        for (let i = 0; i < uploadObj.filesData.length; i++) {
            var fileSize = uploadObj.filesData[i].size;
            if (fileSize < 5000000) {
                var newGuid = createGuid();
                var fileName = uploadObj.filesData[i].name;
                var extension = getFileExtension(fileName);
                if (extension.toLowerCase() == 'pdf' || extension.toLowerCase() == 'jpg' || extension.toLowerCase() == 'jpeg') { // || extension.toLowerCase() == 'jpg' || extension.toLowerCase() == 'jpeg'
                    files.push({ Id: newGuid, Name: fileName, Extention: extension.toLowerCase(), Size: fileSize });
                    uploadObj.filesData[i].name = newGuid + '.' + extension.toLowerCase();
                }
            }
        }
    }

    if (uploadObjTemp != null) {
        for (let i = 0; i < uploadObjTemp.filesData.length; i++) {
            var fileSize = uploadObjTemp.filesData[i].size;
            if (fileSize < 50000000) {
                var newGuid = createGuid();
                var fileName = uploadObjTemp.filesData[i].name;
                var extension = getFileExtension(fileName);
                files.push({ Id: newGuid, Name: fileName, Extention: extension.toLowerCase(), Size: fileSize, IsTemp: true });
                uploadObjTemp.filesData[i].name = newGuid + '.' + extension.toLowerCase();
            }
        }
    }

    if (newDraft == 'True') {
        var message = JSON.stringify(
            {
                Body: body.value,
                Title: title.value,
                ResponsibilityCode: respCode,
                Documents: files
            }
        );
    }
    else {
        var message = JSON.stringify(
            {
                Id: draftId,
                Body: body.value,
                Title: title.value,
                ResponsibilityCode: respCode,
                Documents: files
            }
        );
    }


    const Http = new XMLHttpRequest();
    Http.onreadystatechange = function () { // listen for state changes
        if (Http.readyState == 4 && Http.status == 200) { // when completed we can move away
            alert("تم الحفظ بنجاح");
            window.location = "/SubUsers/CreateDraft";
        }
    }
    uploadObj.upload(uploadObj.getFilesData());
    uploadObjTemp.upload(uploadObjTemp.getFilesData());
    if (newDraft == 'True') {
        url = '/SubUsers/NewDraft';
    }
    else {
        url = '/SubUsers/SaveDraft';
    }
    Http.open("POST", url);
    Http.setRequestHeader('Content-Type', 'application/json');
    Http.send(message);
};

function send(UnFormal) {//, storedFiles
    //if (validateNewMessageForm() == false)
    //    return false;

    var body = document.getElementById('body').ej2_instances[0];
    var title = document.getElementById('title');
    var serialEle = document.getElementById('serial');
    var lserialEle = document.getElementById('lserial');
    var OriginalMessageEle = document.getElementById('OriginalMessageId');
    var senderDiscription = document.getElementById('senderDiscription');
    var senderResponsibilityCode = document.getElementById('senderResponsibilityCode');
    var SenderDesignationId = document.getElementById('SenderDesignationId');
    var DaysToReplay = document.getElementById('DaysToReplay');
    var contactsArr = document.getElementById('UsersList');
    var CCcontactsArr = document.getElementById('CCUsersList');
    var categoriesArr = document.getElementById('CategoriesList');
    var uploadObj = document.getElementById("UploadFiles").ej2_instances[0];
    var uploadObjTemp = document.getElementById("UploadTempFiles").ej2_instances[0];
    var recipints = [];
    var categories = [];
    var files = [];
    
    if (UnFormal == 'True') {
        for (var option of contactsArr.options) {
            if (option.selected) {
                recipints.push({ RecipintId: option.value });
            }
        }
        if (CCcontactsArr != null) {
            for (var option of CCcontactsArr.options) {
                if (option.selected) {
                    recipints.push({ RecipintId: option.value, IsCC: true });
                }
            }
        }
    }
    else {
        if (DaysToReplay == null) {
            for (var option of contactsArr.options) {
                if (option.selected) {
                    recipints.push({ RecipintId: option.value });
                }
            }
        }
        else {
            let days = 0;
            if (DaysToReplay.value != '') {
                days = parseInt(DaysToReplay.value);
            }
            for (var option of contactsArr.options) {
                if (option.selected) {
                    recipints.push({ RecipintId: option.value, DaysToReplay: days });
                }
            }
        }

        if (CCcontactsArr != null) {
            for (var option of CCcontactsArr.options) {
                if (option.selected) {
                    recipints.push({ RecipintId: option.value, IsCC: true });
                }
            }
        }

        if (categoriesArr == null)
            categories = null;
        else {
            for (var option of categoriesArr.options) {
                if (option.selected) {
                    categories.push({ CategoryId: option.value, CategoryName: option.text });
                }
            }
        }
    }

    for (let i = 0; i < uploadObj.filesData.length; i++) {
        var fileSize = uploadObj.filesData[i].size;
        if (fileSize < 5000000) {
            var newGuid = createGuid();
            var fileName = uploadObj.filesData[i].name;
            var extension = getFileExtension(fileName);
            if (extension.toLowerCase() == 'pdf' || extension.toLowerCase() == 'jpg' || extension.toLowerCase() == 'jpeg') { // || extension.toLowerCase() == 'jpg' || extension.toLowerCase() == 'jpeg'
                files.push({ Id: newGuid, Name: fileName, Extention: extension.toLowerCase(), Size: fileSize, IsTemp: false });
                uploadObj.filesData[i].name = newGuid + '.' + extension.toLowerCase();
            }
        }
    }

    for (let i = 0; i < uploadObjTemp.filesData.length; i++) {
        var fileSize = uploadObjTemp.filesData[i].size;
        if (fileSize < 50000000) {
            var newGuid = createGuid();
            var fileName = uploadObjTemp.filesData[i].name;
            var extension = getFileExtension(fileName);
            files.push({ Id: newGuid, Name: fileName, Extention: extension.toLowerCase(), Size: fileSize, IsTemp: true });
            uploadObjTemp.filesData[i].name = newGuid + '.' + extension.toLowerCase();
        }
    }
    //for (let i = 0; i < storedFiles.length; i++) {
    //    var newGuid = createGuid();
    //    var myFile = blobToFile(storedFiles[i], "my-image.png");
    //    uploadObjTemp.upload(myFile);
    //    files.push({ Id: newGuid, Name: 'scanner-' + i, Extention: 'jpeg', Size: 0, IsTemp: false });
    //}

    //var bodyText;
    //if (nav.classList.contains("active")) {
    //    bodyText = body.value;
    //}

    var serial;
    if (serialEle == null)
        serial = null;
    else
        serial = serialEle.value + '-' + ('0000' + lserialEle.value).slice(-4);

    var respCode;
    if (senderResponsibilityCode == null)
        respCode = null;
    else
        respCode = senderResponsibilityCode.value;

    var designationId;
    if (SenderDesignationId == null)
        designationId = 0;
    else
        designationId = parseInt(SenderDesignationId.value);

    var OriginalMessage;
    if (OriginalMessageEle == null)
        OriginalMessage = null
    else
        OriginalMessage = OriginalMessageEle.value

    var bodyValue;
    if (uploadObj.filesData.length > 0)
        bodyValue = ''
    else
        bodyValue = body.value

    var message = JSON.stringify(
        {
            IsOrigin: true,
            Body: bodyValue,
            Title: title.value,
            SerialNumber: serial,
            OriginMessageId: OriginalMessage,
            SenderDiscription: senderDiscription.value,
            ResponsibilityCode: respCode,
            DesignationId: designationId,
            Packages: recipints,
            MessagesCategories: categories,
            Documents: files
        }
    );

    const Http = new XMLHttpRequest();
    Http.onreadystatechange = function () { // listen for state changes
        if (Http.readyState == 4 && Http.status == 200) { // when completed we can move away
            alert("تم الإرسال بنجاح");
            window.location = "/Messages/Inbox";
        }
    }
    if (UnFormal == 'True') {
        url = '/Messages/SendUnFormalMessage';
    }
    else {
        url = '/Messages/SendFormalMessage';
    }

    uploadObj.upload(uploadObj.getFilesData());
    uploadObjTemp.upload(uploadObjTemp.getFilesData());
    
    setTimeout(function () {
        Http.open("POST", url);
        Http.setRequestHeader('Content-Type', 'application/json');
        Http.send(message);
    }, 5000);
};

function sendDraft(UnFormal) {
    //if (validateNewMessageForm() == false)
    //    return false;
    var messageId = document.getElementById('messageId');
    var body = document.getElementById('body').ej2_instances[0];
    var title = document.getElementById('title');
    var serialEle = document.getElementById('serial');
    var lserialEle = document.getElementById('lserial');
    var OriginalMessageEle = document.getElementById('OriginalMessageId');
    var senderDiscription = document.getElementById('senderDiscription');
    var senderResponsibilityCode = document.getElementById('senderResponsibilityCode');
    var SenderDesignationId = document.getElementById('SenderDesignationId');
    var contactsArr = document.getElementById('UsersList');
    var CCcontactsArr = document.getElementById('CCUsersList');
    var DaysToReplay = document.getElementById('DaysToReplay');
    var categoriesArr = document.getElementById('CategoriesList');
    var uploadObj = document.getElementById("UploadFiles").ej2_instances[0];
    var uploadObjTemp = document.getElementById("UploadTempFiles").ej2_instances[0];
    //var oldDocuments = document.getElementsByClassName('oldDocuments');
    var recipints = [];
    var categories = [];
    var files = [];

    if (UnFormal == 'True') {
        for (var option of contactsArr.options) {
            if (option.selected) {
                recipints.push({ RecipintId: option.value });
            }
        }
        if (CCcontactsArr != null) {
            for (var option of CCcontactsArr.options) {
                if (option.selected) {
                    recipints.push({ RecipintId: option.value, IsCC: true });
                }
            }
        }
    }
    else {
        if (DaysToReplay == null) {
            for (var option of contactsArr.options) {
                if (option.selected) {
                    recipints.push({ RecipintId: option.value });
                }
            }
        }
        else {
            let days = 0;
            if (DaysToReplay.value != '') {
                days = parseInt(DaysToReplay.value);
            }
            for (var option of contactsArr.options) {
                if (option.selected) {
                    recipints.push({ RecipintId: option.value, DaysToReplay: days });
                }
            }
        }
        if (CCcontactsArr != null) {
            for (var option of CCcontactsArr.options) {
                if (option.selected) {
                    recipints.push({ RecipintId: option.value, IsCC: true });
                }
            }
        }

        if (categoriesArr == null)
            categories = null;
        else {
            for (var option of categoriesArr.options) {
                if (option.selected) {
                    categories.push({ CategoryId: option.value, CategoryName: option.text });
                }
            }
        }

        for (let i = 0; i < uploadObj.filesData.length; i++) {
            var fileSize = uploadObj.filesData[i].size;
            if (fileSize < 5000000) {
                var newGuid = createGuid();
                var fileName = uploadObj.filesData[i].name;
                var extension = getFileExtension(fileName);
                if (extension.toLowerCase() == 'pdf' || extension.toLowerCase() == 'jpg' || extension.toLowerCase() == 'jpeg') { // || extension.toLowerCase() == 'jpg' || extension.toLowerCase() == 'jpeg'
                    files.push({ Id: newGuid, Name: fileName, Extention: extension.toLowerCase(), Size: fileSize, IsTemp: false });
                    uploadObj.filesData[i].name = newGuid + '.' + extension.toLowerCase();
                }
            }
        }
    }

    for (let i = 0; i < uploadObjTemp.filesData.length; i++) {
        var fileSize = uploadObjTemp.filesData[i].size;
        if (fileSize < 50000000) {
            var newGuid = createGuid();
            var fileName = uploadObjTemp.filesData[i].name;
            var extension = getFileExtension(fileName);
            files.push({ Id: newGuid, Name: fileName, Extention: extension.toLowerCase(), Size: fileSize, IsTemp: true });
            uploadObjTemp.filesData[i].name = newGuid + '.' + extension.toLowerCase();
        }
    }

    var serial;
    if (serialEle == null)
        serial = null;
    else
        serial = serialEle.value + '-' + ('0000' + lserialEle.value).slice(-4);

    var respCode;
    if (senderResponsibilityCode == null)
        respCode = null;
    else
        respCode = senderResponsibilityCode.value;

    var designationId;
    if (SenderDesignationId == null || SenderDesignationId.value == '')
        designationId = 0;
    else
        designationId = parseInt(SenderDesignationId.value);

    var OriginalMessage;
    if (OriginalMessageEle == null)
        OriginalMessage = null
    else
        OriginalMessage = OriginalMessageEle.value

    //for (let i = 0; i < oldDocuments.length; i++) {
    //    files.push({ Id: oldDocuments[i].value });
    //}

    var message = JSON.stringify(
        {
            IsOrigin: true,
            Id: messageId.value,
            Body: body.value,
            Title: title.value,
            SerialNumber: serial,
            OriginMessageId: OriginalMessage,
            SenderDiscription: senderDiscription.value,
            ResponsibilityCode: respCode,
            DesignationId: designationId,
            Packages: recipints,
            MessagesCategories: categories,
            Documents: files
        }
    );

    const Http = new XMLHttpRequest();
    Http.onreadystatechange = function () { // listen for state changes
        if (Http.readyState == 4 && Http.status == 200) { // when completed we can move away
            alert("تم الإرسال بنجاح");
            window.location = "/Messages/Inbox";
        }
    }
    url = '/Messages/SendDraft';
    uploadObj.upload(uploadObj.getFilesData());
    uploadObjTemp.upload(uploadObjTemp.getFilesData());
    setTimeout(function () {
        Http.open("POST", url);
        Http.setRequestHeader('Content-Type', 'application/json');
        Http.send(message);
    }, 5000);
};

function sendGeneral(lowLevel) {
    //if (validateGeneralMessageForm() == false)
    //    return false;
    var body = document.getElementById('body').ej2_instances[0];
    var title = document.getElementById('title');
    //var serialEle = document.getElementById('serial');
    var OriginalMessageEle = document.getElementById('OriginalMessageId');
    var senderDiscription = document.getElementById('senderDiscription');
    var senderResponsibilityCode = document.getElementById('senderResponsibilityCode');

    var categoriesArr = document.getElementById('CategoriesList');
    var uploadObj = document.getElementById("UploadFiles").ej2_instances[0];
    var uploadObjTemp = document.getElementById("UploadTempFiles").ej2_instances[0];
    var categories = [];
    var files = [];

    for (var option of categoriesArr.options) {
        if (option.selected) {
            categories.push({ CategoryId: option.value, CategoryName: option.text });
        }
    }

    //var serial;
    //if (serialEle == null)
    //    serial = null;
    //else
    //    serial = serialEle.value;

    var respCode;
    if (senderResponsibilityCode == null)
        respCode = null;
    else
        respCode = senderResponsibilityCode.value;

    var OriginalMessage;
    if (OriginalMessageEle == null)
        OriginalMessage = null
    else
        OriginalMessage = OriginalMessageEle.value

    for (let i = 0; i < uploadObj.filesData.length; i++) {
        var fileSize = uploadObj.filesData[i].size;
        if (fileSize < 5000000) {
            var newGuid = createGuid();
            var fileName = uploadObj.filesData[i].name;
            var extension = getFileExtension(fileName);
            if (extension.toLowerCase() == 'pdf' || extension.toLowerCase() == 'jpg' || extension.toLowerCase() == 'jpeg') { // || extension.toLowerCase() == 'jpg' || extension.toLowerCase() == 'jpeg'
                files.push({ Id: newGuid, Name: fileName, Extention: extension.toLowerCase(), Size: fileSize });
                uploadObj.filesData[i].name = newGuid + '.' + extension.toLowerCase();
            }
        }
    }

    for (let i = 0; i < uploadObjTemp.filesData.length; i++) {
        var fileSize = uploadObjTemp.filesData[i].size;
        if (fileSize < 50000000) {
            var newGuid = createGuid();
            var fileName = uploadObjTemp.filesData[i].name;
            var extension = getFileExtension(fileName);
            files.push({ Id: newGuid, Name: fileName, Extention: extension.toLowerCase(), Size: fileSize, IsTemp: true });
            uploadObjTemp.filesData[i].name = newGuid + '.' + extension.toLowerCase();
        }
    }

    var message = JSON.stringify(
        {
            IsOrigin: true,
            Body: body.value,
            Title: title.value,
            SerialNumber: null,
            OriginMessageId: OriginalMessage,
            SenderDiscription: senderDiscription.value,
            ResponsibilityCode: respCode,
            MessagesCategories: categories,
            Documents: files
        }
    );

    const Http = new XMLHttpRequest();
    Http.onreadystatechange = function () { // listen for state changes
        if (Http.readyState == 4 && Http.status == 200) { // when completed we can move away
            alert("تم الإرسال بنجاح");
            window.location = "/Messages/Inbox";
        }
    }
    if (lowLevel == 'True')
        url = '/Messages/SendGeneralMessageForLowLevel';
    else
        url = '/Messages/SendGeneralMessage';
    uploadObj.upload(uploadObj.getFilesData());
    uploadObjTemp.upload(uploadObjTemp.getFilesData());
    setTimeout(function () {
        Http.open("POST", url);
        Http.setRequestHeader('Content-Type', 'application/json');
        Http.send(message);
    }, 5000);
};

function sendGeneralDraft(lowLevel) {
    //if (validateGeneralMessageForm() == false)
    //    return false;
    var messageId = document.getElementById('messageId');
    var body = document.getElementById('body').ej2_instances[0];
    var title = document.getElementById('title');
    //var serialEle = document.getElementById('serial');
    var senderDiscription = document.getElementById('senderDiscription');
    var senderResponsibilityCode = document.getElementById('senderResponsibilityCode');
    var categoriesArr = document.getElementById('CategoriesList');
    var OriginalMessageEle = document.getElementById('OriginalMessageId');
    var uploadObj = document.getElementById("UploadFiles").ej2_instances[0];
    var uploadObjTemp = document.getElementById("UploadTempFiles").ej2_instances[0];
    var categories = [];
    var files = [];

    for (var option of categoriesArr.options) {
        if (option.selected) {
            categories.push({ CategoryId: option.value, CategoryName: option.text });
        }
    }

    //var serial;
    //if (serialEle == null)
    //    serial = null;
    //else
    //    serial = serialEle.value;

    var respCode;
    if (senderResponsibilityCode == null)
        respCode = null;
    else
        respCode = senderResponsibilityCode.value;

    var OriginalMessage;
    if (OriginalMessageEle == null)
        OriginalMessage = null
    else
        OriginalMessage = OriginalMessageEle.value

    for (let i = 0; i < uploadObj.filesData.length; i++) {
        var fileSize = uploadObj.filesData[i].size;
        if (fileSize < 5000000) {
            var newGuid = createGuid();
            var fileName = uploadObj.filesData[i].name;
            var extension = getFileExtension(fileName);
            if (extension.toLowerCase() == 'pdf' || extension.toLowerCase() == 'jpg' || extension.toLowerCase() == 'jpeg') { // || extension.toLowerCase() == 'jpg' || extension.toLowerCase() == 'jpeg'
                files.push({ Id: newGuid, Name: fileName, Extention: extension.toLowerCase(), Size: fileSize });
                uploadObj.filesData[i].name = newGuid + '.' + extension.toLowerCase();
            }
        }
    }

    for (let i = 0; i < uploadObjTemp.filesData.length; i++) {
        var fileSize = uploadObjTemp.filesData[i].size;
        if (fileSize < 50000000) {
            var newGuid = createGuid();
            var fileName = uploadObjTemp.filesData[i].name;
            var extension = getFileExtension(fileName);
            files.push({ Id: newGuid, Name: fileName, Extention: extension.toLowerCase(), Size: fileSize, IsTemp: true });
            uploadObjTemp.filesData[i].name = newGuid + '.' + extension.toLowerCase();
        }
    }

    var message = JSON.stringify(
        {
            IsOrigin: true,
            Id: messageId.value,
            Body: body.value,
            Title: title.value,
            //SerialNumber: serial,
            OriginMessageId: OriginalMessage,
            SenderDiscription: senderDiscription.value,
            ResponsibilityCode: respCode,
            MessagesCategories: categories,
            Documents: files
        }
    );

    const Http = new XMLHttpRequest();
    Http.onreadystatechange = function () { // listen for state changes
        if (Http.readyState == 4 && Http.status == 200) { // when completed we can move away
            alert("تم الإرسال بنجاح");
            window.location = "/Messages/Inbox";
        }
    }
    if (lowLevel == 'True')
        url = '/Messages/SendGeneralDraftForLowLevel';
    else
        url = '/Messages/SendGeneralDraft';
    uploadObj.upload(uploadObj.getFilesData());
    uploadObjTemp.upload(uploadObjTemp.getFilesData());
    setTimeout(function () {
        Http.open("POST", url);
        Http.setRequestHeader('Content-Type', 'application/json');
        Http.send(message);
    }, 5000);
};

function forward(Serial) {
    //if (validateForwardForm() == false)
    //    return false;
    var body = document.getElementById('body_f');
    var title = document.getElementById('title_f');
    var senderDiscription = document.getElementById('senderDiscription');
    var senderResponsibilityCode = document.getElementById('senderResponsibilityCode');
    var OriginalMessageEle = document.getElementById('OriginalMessageId_f');
    var contactsArr = document.getElementById('UsersList_f');
    var uploadObj = document.getElementById("UploadFiles").ej2_instances[0];
    var uploadObjTemp = document.getElementById("UploadTempFiles").ej2_instances[0];
    var recipints = [];
    var files = [];

    if (Serial == '') {
        for (var option of contactsArr.options) {
            if (option.selected) {
                recipints.push({ RecipintId: option.value });
            }
        }
    }
    else {
        for (var option of contactsArr.options) {
            if (option.selected) {
                recipints.push({ RecipintId: option.value });
            }
        }
    }

    var respCode;
    if (senderResponsibilityCode == null)
        respCode = null;
    else
        respCode = senderResponsibilityCode.value;

    for (let i = 0; i < uploadObj.filesData.length; i++) {
        var fileSize = uploadObj.filesData[i].size;
        if (fileSize < 5000000) {
            var newGuid = createGuid();
            var fileName = uploadObj.filesData[i].name;
            var extension = getFileExtension(fileName);
            if (extension.toLowerCase() == 'pdf' || extension.toLowerCase() == 'jpg' || extension.toLowerCase() == 'jpeg') { // || extension.toLowerCase() == 'jpg' || extension.toLowerCase() == 'jpeg'
                files.push({ Id: newGuid, Name: fileName, Extention: extension.toLowerCase(), Size: fileSize, IsTemp: false });
                uploadObj.filesData[i].name = newGuid + '.' + extension.toLowerCase();
            }
        }
    }

    for (let i = 0; i < uploadObjTemp.filesData.length; i++) {
        var fileSize = uploadObjTemp.filesData[i].size;
        if (fileSize < 50000000) {
            var newGuid = createGuid();
            var fileName = uploadObjTemp.filesData[i].name;
            var extension = getFileExtension(fileName);
            files.push({ Id: newGuid, Name: fileName, Extention: extension.toLowerCase(), Size: fileSize, IsTemp: true });
            uploadObjTemp.filesData[i].name = newGuid + '.' + extension.toLowerCase();
        }
    }

    var message = JSON.stringify(
        {
            IsOrigin: false,
            SerialNumber: Serial,
            Body: body.value,
            Title: title.value,
            SenderDiscription: senderDiscription.value,
            ResponsibilityCode: respCode,
            OriginMessageId: OriginalMessageEle.value,
            Packages: recipints,
            Documents: files
        }
    );
    const Http = new XMLHttpRequest();
    Http.onreadystatechange = function () { // listen for state changes
        if (Http.readyState == 4 && Http.status == 200) { // when completed we can move away
            alert("تم الإرسال بنجاح");
            location.reload();
        }
    }
    if (Serial == '')
        url = '/Messages/SendUnFormalMessage';
    else
        url = '/Messages/SendFormalMessage';
    uploadObj.upload(uploadObj.getFilesData());
    uploadObjTemp.upload(uploadObjTemp.getFilesData());
    setTimeout(function () {
        Http.open("POST", url);
        Http.setRequestHeader('Content-Type', 'application/json');
        Http.send(message);
    }, 5000);
};

function getFileExtension(filename) {

    const extension = filename.split('.').pop();
    return extension;
};

function getFileName(id) {
    var fullPath = document.getElementById(id).value;
    if (fullPath) {
        var startIndex = (fullPath.indexOf('\\') >= 0 ? fullPath.lastIndexOf('\\') : fullPath.lastIndexOf('/'));
        var filename = fullPath.substring(startIndex);
        if (filename.indexOf('\\') === 0 || filename.indexOf('/') === 0) {
            filename = filename.substring(1);
        }
        return (filename);
    }
};

function ShowRecipintsModal() {
    $("#RecipintsModal").appendTo("body");
};

function makeId(length) {
    var result = '';
    var characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
    var charactersLength = characters.length;
    for (var i = 0; i < length; i++) {
        result += characters.charAt(Math.floor(Math.random() *
            charactersLength));
    }
    return result;
};

function createGuid() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16 | 0, v = c === 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    });
};

function onFileSelected(args) {
    // Filter the 3 files only to showcase
    var uploadObj = document.getElementById("UploadFiles")
    //args.filesData.splice(3);
    var filesData = uploadObj.ej2_instances[0].getFilesData();
    var allFiles = filesData.concat(args.filesData);
    for (let i = 0; i < args.filesData.length; i++) {
        var extension = getFileExtension(args.filesData[i].name);
        if (extension.toLowerCase() == 'pdf' || extension.toLowerCase() == 'doc' || extension.toLowerCase() == 'docx' || extension.toLowerCase() == 'jpg' || extension.toLowerCase() == 'jpeg') {
            if (args.filesData[i].size > 5000000) {
                args.cancel = true;
                alert('لا يمكن إضافة بحجم يزيد عن 5 MB');
                break;
            }
            if (allFiles.length > 5) {
                args.cancel = true;
                alert('لا يمكن إضافة أكثر من خمسة ملفات إلى المراسلة');
                break;
            }
        }
        else {
            args.cancel = true;
            alert('لا يمكن إضافة هذا النوع من الملفات لملف المراسلة');
            break;
        }
    }

};

function onTempFileSelected(args) {
    // Filter the 3 files only to showcase
    var uploadObj = document.getElementById("UploadTempFiles")
    //args.filesData.splice(3);
    var filesData = uploadObj.ej2_instances[0].getFilesData();
    var allFiles = filesData.concat(args.filesData);
    for (let i = 0; i < args.filesData.length; i++) {
        if (args.filesData[i].size > 50000000) {
            args.cancel = true;
            alert('لا يمكن إضافة بحجم يزيد عن 50 MB');
            break;
        }
        if (allFiles.length > 10) {
            args.cancel = true;
            alert('لا يمكن إضافة أكثر من عشر ملفات إلى المراسلة');
            break;
        }
    }

};

//function addContactFromFavList(e) {
//    addContact(e.options[e.selectedIndex].value, e.options[e.selectedIndex].text);
//};

//function addContactFromAllList(e) {
//    addContact(e.options[e.selectedIndex].value, e.options[e.selectedIndex].text);
//};

//function addContact(id, name) {
//    var itmDiv = document.createElement("div");
//    itmDiv.classList.add("p-2", "border", "ml-1", "mt-1");
//    itmDiv.id = id + '_m';

//    var NameDiv = document.createElement("div");
//    NameDiv.style.display = "inline-flex";
//    NameDiv.innerHTML = name;

//    var closeBtn = document.createElement("button");
//    closeBtn.classList.add("close");
//    closeBtn.type = "button";
//    closeBtn.onclick = function () { deleteObject(id); };

//    var closeSpan = document.createElement("Span");
//    closeSpan.innerHTML = "&times;";

//    closeBtn.appendChild(closeSpan);
//    itmDiv.appendChild(NameDiv);
//    itmDiv.appendChild(closeBtn);

//    document.getElementById("ftDiv").appendChild(itmDiv);

//    let clone = document.getElementById(id + "_m").cloneNode(true);
//    clone.setAttribute('id', id + '_f');

//    document.getElementById("contactsDiv").appendChild(clone);
//    document.getElementById(id + '_f').classList.add("contact");
//    document.getElementById(id + '_f').getElementsByClassName("close")[0].onclick = function () { deleteObject(id); };
//};

//function deleteObject(id) {
//    var f = document.getElementById(id + "_f");
//    f.remove();
//    var m = document.getElementById(id + "_m");
//    m.remove();
//};

//function deleteFileObject(id) {
//    var obj = document.getElementById(id);
//    obj.remove();
//};

//function LoadFiles() {
//    var fld = document.getElementById("inputFile");
//    if (fld.files.length == 0) {
//        alert("يرجى اختيار ملف لرفعه");
//    }
//    else if (fld.files[0].size > 1173741824) {
//        alert("حجم الملف تجاوز 1 جيجا!");
//        fld.value = "";
//    }
//    else {
//        fld.style.display = "none";
//        var id = makeId(6);
//        var itmDiv = document.createElement("div");
//        itmDiv.classList.add("bg-light", "text-truncate", "mb-1", "text-right");
//        itmDiv.id = id;

//        var link = document.createElement("a");
//        link.setAttribute("href", "#");
//        link.innerHTML = fld.files[0].name;

//        var i = document.createElement("i");
//        i.classList.add("fa", "fa-file-pdf", "fa-2x");
//        i.setAttribute("aria-hidden", "true");
//        i.style.color = "firebrick";

//        var closeBtn = document.createElement("button");
//        closeBtn.classList.add("close");
//        closeBtn.type = "button";
//        closeBtn.onclick = function () { deleteFileObject(id); };
//        closeBtn.style.position = "absolute";
//        closeBtn.style.left = "0";
//        //closeBtn.style.top = "10%";

//        var closeSpan = document.createElement("Span");
//        closeSpan.innerHTML = "&times;";

//        var clone = $("#inputFile").clone();
//        clone.attr("id", id + "_f");
//        clone.attr("hidden", "hidden");
//        clone.attr("onchange", null);
//        clone.addClass("files");
//        $("#inputFile").val = "";

//        closeBtn.appendChild(closeSpan);
//        link.appendChild(i);
//        itmDiv.appendChild(link);
//        itmDiv.appendChild(closeBtn);
//        clone.after().appendTo(itmDiv);

//        document.getElementById("filesDiv").appendChild(itmDiv);

//        //var x = document.getElementById("LoadingDIV");
//        //x.style.display = "block";
//    }
//};

