function validateNaziv() {
   


    var naziv = document.forms["form"]["Naziv"].value.trim();
    if (naziv == "") {
        document.getElementById("validation").style.display = "block"
        return false;
    }
  
    else {
        document.getElementById("validation").style.display = "none"
        return true;
    }
   
}



