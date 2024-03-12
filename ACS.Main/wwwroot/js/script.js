let sidebar = document.querySelector(".sidebar");
let closeBtn = document.querySelector("#btn");
let searchBtn = document.querySelector(".bx-search"); 
let logo_name = document.querySelector(".logo_name");
let dropdown_content = document.querySelector(".dropdown-content");

closeBtn.addEventListener("click", ()=>{
  sidebar.classList.toggle("open");
  menuBtnChange();//calling the function(optional)
});

searchBtn.addEventListener("click", ()=>{ // Sidebar open when you click on the search iocn
  sidebar.classList.toggle("open");
  menuBtnChange(); //calling the function(optional)
});

// following are the code to change sidebar button(optional)
function menuBtnChange() {
    if (sidebar.classList.contains("open")) {
        closeBtn.classList.replace("fa-bars", "fa-minus");//replacing the iocns class
        dropdown_content.style.right = "222px";
    } else {
        closeBtn.classList.replace("fa-minus", "fa-bars");//replacing the iocns class
        dropdown_content.style.right = "50px";
    }
};

//////////////////////////////////////////////////

function queryCellInfo(args) {
    if (args.column.field == "IsReaded" && args.data['IsReaded'] == false) {

        /*$($(args.cell).parent()).css("backgroundColor", "yellow");*/
        args.cell.style.backgroundColor = "goldenrod";
        args.cell.textContent = "لا";
        //args.cell.classList.add('font-weight-bolder');

    }
    else if (args.column.field == "IsReaded" && args.data['IsReaded'] == true) {
        args.cell.textContent = "نعم";
        args.cell.style.backgroundColor = "silver";
    }
    //if (args.column.field === 'IsReaded') {
    //    if (args.cell.textContent === "true") {
    //        args.cell.querySelector(".statustxt").classList.add("e-activecolor");
    //        args.cell.querySelector(".statustemp").classList.add("e-activecolor");
    //    }
    //    if (args.cell.textContent === "false") {
    //        args.cell.querySelector(".statustxt").classList.add("e-inactivecolor");
    //        args.cell.querySelector(".statustemp").classList.add("e-inactivecolor");
    //    }
    //}
};

function rowSelected(args) {
    location.href = '/Messages/Message/' + args.data['Id'];
};

function rowSelectedForDraft(args) {
    location.href = '/Messages/EditDraft/' + args.data['Id'];
};

function rowSelectedDeleteMessage(args) {
    location.href = '/Messages/DeletedMessage/' + args.data['Id'];
};

function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;
    return true;
};

