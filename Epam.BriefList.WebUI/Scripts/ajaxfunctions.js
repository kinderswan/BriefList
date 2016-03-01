   
    function onSuccess() {
        window.scrollTo(0, 0);
        $("#change").html('<div class="alert alert-success"> ' + 'Данные успешно изменены' + '</div>').show()
        setTimeout(function() { $("#change").fadeOut('fast') }, 3000);
    };

      function onFailure() {
        window.scrollTo(0, 0);
        $("#changefail").html('<div class="alert alert-danger"> ' + 'Введите измененные данные' + '</div>').show()
        setTimeout(function() { $("#changefail").fadeOut('fast') }, 3000);
    };

     function onFailureSearch() {
        window.scrollTo(0, 0);
        $("#changefail").html('<div class="alert alert-danger"> ' + 'Поиск не дал результатов' + '</div>').show()
        setTimeout(function() { $("#changefail").fadeOut('fast') }, 3000);
     };

     function modalOnSuccess() {
         $("#modDialog").show();
         document.getElementById("window").style.background = 'grey';
     }
     function closeWindow() {
         $('#modDialog').hide();
     }

    /*
    //не работают почему-то!
     function modalOnSuccess() {
         $("#modDialog").show();
     }

     function closeWindow() {
         $("#modDialog").hide();
     }
     */
   /* function LotCathegory() {

        $("#cathegorymenu").load("/Admin/BarLots")
    };

    function UserCathegory() {
        $("#cathegorymenu").load("/Admin/BarUsers")
    };*/
