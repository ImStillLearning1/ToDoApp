//Projects
if (document.getElementById("project-list") != null) {
    document.getElementById("project-list").addEventListener("click", function (e) {

        if (e.target.classList.contains("delete-button")) {
            document.getElementById("deleteProjectValue").value = e.target.value;
            document.getElementById("overlay").classList.add("active");
            document.getElementById("prompt-project").classList.add("active");
        }
        else if (e.target.parentNode.classList.contains("delete-button")) {
            document.getElementById("deleteProjectValue").value = e.target.parentNode.value;
            document.getElementById("overlay").classList.add("active");
            document.getElementById("prompt-project").classList.add("active");
        }


    });
}

if (document.getElementById("reject-project") != null) {
    document.getElementById("reject-project").addEventListener("click", function (e) {
        document.getElementById("overlay").classList.remove("active");
        document.getElementById("prompt-project").classList.remove("active");
    });
}



//Duties
if (document.getElementById("duties") != null) {
    document.getElementById("duties").addEventListener("click", function (e) {

        if (e.target.classList.contains("delete-button")) {
            document.getElementById("deleteDutyValue").value = e.target.value;
            document.getElementById("overlay").classList.add("active");
            document.getElementById("prompt-duty").classList.add("active");
        }
        else if (e.target.parentNode.classList.contains("delete-button")) {
            document.getElementById("deleteDutyValue").value = e.target.parentNode.value;
            document.getElementById("overlay").classList.add("active");
            document.getElementById("prompt-duty").classList.add("active");
        }
    });
}

if (document.getElementById("reject-duty") != null) {
    document.getElementById("reject-duty").addEventListener("click", function (e) {
        document.getElementById("overlay").classList.remove("active");
        document.getElementById("prompt-duty").classList.remove("active");
    })
}


//Events
if (document.getElementById("events") != null) {
    document.getElementById("events").addEventListener("click", function (e) {

        if (e.target.classList.contains("delete-button")) {
            document.getElementById("deleteEventValue").value = e.target.value;
            document.getElementById("overlay").classList.add("active");
            document.getElementById("prompt-event").classList.add("active");
        }
        else if (e.target.parentNode.classList.contains("delete-button")) {
            document.getElementById("deleteEventValue").value = e.target.parentNode.value;
            document.getElementById("overlay").classList.add("active");
            document.getElementById("prompt-event").classList.add("active");
        }
    });
}

if (document.getElementById("reject-event") != null) {
    document.getElementById("reject-event").addEventListener("click", function (e) {
        document.getElementById("overlay").classList.remove("active");
        document.getElementById("prompt-event").classList.remove("active");
    })
}


////Home
//if (document.getElementById("signIn-button") != null && document.getElementById("signUp-button") != null) {
//    document.getElementById("signIn-button").addEventListener("mouseover", function (e) {
//        document.getElementById("home-section").classList.add("active-signIn");
//    });

//    document.getElementById("signUp-button").addEventListener("mouseover", function (e) {
//        document.getElementById("home-section").classList.add("active-signUp");
//    });

//    document.getElementById("signIn-button").addEventListener("mouseleave", function (e) {
//        document.getElementById("home-section").classList.remove("active-signIn");
//    });

//    document.getElementById("signUp-button").addEventListener("mouseleave", function (e) {
//        document.getElementById("home-section").classList.remove("active-signUp");
//    });
//}
