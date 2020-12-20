$("#AddQOEButton").click(function (event) {
    let dataToLoad = `/QOEs/Create`;

    $.get(dataToLoad, function (data) {

    })
        .then(data => {
            let formData = $(data).find("#QOESubjectLine");
            //$("#AdditionalQOEsArea").html("TEST");
            $("#QOEsList").append(formData);
            attachQOEAddedFunctions();

            console.log(dataToLoad + " Loaded");
        })
        .fail(function () {
            let title = `Error Loading Form ${formToLoad}`;
            let content = `The form at ${dataToLoad} returned a server error and could not be loaded`;

            doErrorModal(title, content);
    });
});

function attachQOEAddedFunctions() {
    $(".DeleteQOEButton").click(function (event) {
        let qoeToRemove = $(this).parent().parent().parent().parent();
        qoeToRemove.remove();
    });
}

$(".btn-link").click(function (event) {
    event.stopPropagation();

    let isCollapsed = $(this).attr("aria-expanded");
    let stepNum = $(this).attr("data-interval");

    //Needs work
    $(this).collapse("toggle");
});

function step1Valid() {
    let validator = $("form").validate();
    let applicationTitleValid = validator.element("#Application_Title");
    let applicationForenameValid = validator.element("#Application_Forename");
    let applicationSurnameValid = validator.element("#Application_Surname");
    let applicationDOBValid = validator.element("#Application_DOB");
    let applicationGenderValid = validator.element("#Application_Gender");
    let applicationMobilePhoneValid = validator.element("#Application_MobilePhone");
    let applicationHomePhoneValid = validator.element("#Application_HomePhone");
    let applicationEmailValid = validator.element("#Application_Email");

    if (
        applicationTitleValid === true
        && applicationForenameValid === true
        && applicationSurnameValid === true
        && applicationDOBValid === true
        && applicationGenderValid === true
        && applicationMobilePhoneValid === true
        && applicationHomePhoneValid === true
        && applicationEmailValid === true
    ) {
        return true;
    }
    else {
        return false;
    }
}

$(".NextStep1").click(function (event) {
    var formData = new FormData(document.getElementById("CreateApplicationFields"));
    //var object = {};
    //formData.forEach(function (value, key) {
    //    object[key] = value;
    //});
    //var json = JSON.stringify(object);
    var json = btoa(JSON.stringify(Object.fromEntries(formData))); //base64 encode as cannot store JSON in cookies - use atob to convert back

    var cookieExpireDate = new Date();
    cookieExpireDate.setMinutes(cookieExpireDate.getMinutes() + 60);
    document.cookie = "ApplicationData=" + json + ";expires=" + cookieExpireDate.toUTCString();

    alert(json);
    if (step1Valid()) {
        $("#collapseTwo").collapse("show");
        $("html, body").animate({ scrollTop: $("#accordion").offset().top }, "slow");
    }
});

$(".NextStep2").click(function (event) {
    $("#collapseThree").collapse("show");
    $("html, body").animate({ scrollTop: $("#accordion").offset().top }, "slow");
});

$(".NextStep3").click(function (event) {
    $("#collapseFour").collapse("show");
    $("html, body").animate({ scrollTop: $("#accordion").offset().top }, "slow");
});

$(".SubmitButton").click(function (event) {

});