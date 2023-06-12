$(document).ready(function () {
    if ($(".ChooseCategory").val() > 0) {
        $("#SecondCategoryList1").show();
    } else {
        $("#SecondCategoryList1").hide();
        $("#ThirdCategoryList1").hide();
        $("#FourthCategoryList1").hide();

        /////////////// değerler ////
        $(".SecondCategoryList").val(-1);
        $(".ThirdCategoryList").val(-1);
        $(".FourthCategoryList").val(-1);

    }
});




///////////////////////////////////////////////// birinci /////////////////////////////////////////////////////////////////////////////////////


setTimeout(function () {
    $(function () {

        $(".ChooseCategory").change(function () {

            $(".SecondCategoryList").empty();


            $.ajax({
                url: '/Post/ShowSecondCategory',
                dataType: 'json',
                data: { id: $(".ChooseCategory").val() },
                success: function (data) {

                    $(".SecondCategoryList").append("<option value='-1'> Alt Kateqoriya seçin </option>");

                    $.each(data, (_, item) => {
                        $(".SecondCategoryList").append(`<option value= "${item.value}">${item.text}</option>`);

                    });


                    if ($(".ChooseCategory").val() > 0) {
                        $("#SecondCategoryList1").show();

                    } else { // eger bas kateqoriya -1 olsa onda 2 co kateqoriyada -1 olur ve hide

                        $(".SecondCategoryList").val(-1) 
                        $("#SecondCategoryList1").hide();

                    }

                    // eger bas kataqoruya deyisirse hecneden asli olmayaraq (hamisi 2 ciden basqa cunki mes: heyvan secse ona uygun alt kateqoriya cixmalidir) hide olur ve -1 qiymetini alir

                    //////////////////////// qiymetler ///////////////////////////

                    $(".ThirdCategoryList").val(-1)
                    $(".FourthCategoryList").val(-1)

                    ////////////////// gizlemek /////////////////////////////////


                    $("#ThirdCategoryList1").hide();
                    $("#FourthCategoryList1").hide();

                },




                error: function (error) {
                    console.error(error);
                }
            });

        });

    });

}, 0);


















///////////////////////////////////////////////// ikinci /////////////////////////////////////////////////////////////////////////////////////


















setTimeout(function () {
    $(function () {

        $(".SecondCategoryList").change(function () {

            $(".ThirdCategoryList").empty();

            if ($(".ChooseCategory").val() == 1 || $(".ChooseCategory").val() == 2) { /*ve yaxud catagory adileri 1 dise*/

                $.ajax({
                    url: '/Post/ShowMarks',
                    dataType: 'json',
                    data: { id: $(".SecondCategoryList").val() },
                    success: function (data) {

                        $(".ThirdCategoryList").append("<option value='-1'> Marka seçin </option>");

                        $.each(data, (_, item) => {
                            $(".ThirdCategoryList").append(`<option value= "${item.value}">${item.text}</option>`);

                        });


                        if ($(".SecondCategoryList").val() > 0) {
                            $("#ThirdCategoryList1").show();

                        } else {
                            $(".ThirdCategoryList1").val(-1);
                            $("#ThirdCategoryList1").hide();
                        }

                        // eger bas kataqoruya deyisirse hecneden asli olmayaraq (hamisi 3 ciden basqa cunki mes: heyvan secse ona uygun alt kateqoriya cixmalidir) hide olur ve -1 qiymetini alir


                        //////////////////////// qiymetler ///////////////////////////

                        $(".FourthCategoryList").val(-1)

                        ////////////////// gizlemek /////////////////////////////////
                  
                        $("#FourthCategoryList1").hide();




                    },




                    error: function (error) {
                        console.error(error);
                    }

                });




            } else if ($(".ChooseCategory").val() == 3 ) {
                $.ajax({
                    url: '/Post/ShowCins',
                    dataType: 'json',
                    data: { id: $(".SecondCategoryList").val() },
                    success: function (data) {

                        $(".ThirdCategoryList").append("<option value='-1'> Cins seçin </option>");

                        $.each(data, (_, item) => {
                            $(".ThirdCategoryList").append(`<option value= "${item.value}">${item.text}</option>`);

                        });


                        if ($(".SecondCategoryList").val() > 0) {
                            $("#ThirdCategoryList1").show();

                        } else {
                            $(".ThirdCategoryList1").val(-1);
                            $("#ThirdCategoryList1").hide();
                        }

                        // eger bas kataqoruya deyisirse hecneden asli olmayaraq (hamisi 3 ciden basqa cunki mes: heyvan secse ona uygun alt kateqoriya cixmalidir) hide olur ve -1 qiymetini alir


                        //////////////////////// qiymetler ///////////////////////////

                        $(".FourthCategoryList").val(-1)

                        ////////////////// gizlemek /////////////////////////////////


                        $("#FourthCategoryList1").hide();




                    },




                    error: function (error) {
                        console.error(error);
                    }

                });



            } else if ($(".ChooseCategory").val() == 4) {

                $.ajax({
                    url: '/Post/ShowMalinNovu',
                    dataType: 'json',
                    data: { id: $(".SecondCategoryList").val() },
                    success: function (data) {

                        $(".ThirdCategoryList").append("<option value='-1'> Malin Növünü seçin </option>");

                        $.each(data, (_, item) => {
                            $(".ThirdCategoryList").append(`<option value= "${item.value}">${item.text}</option>`);

                        });


                        if ($(".SecondCategoryList").val() > 0) {
                            $("#ThirdCategoryList1").show();

                        } else {
                            $(".ThirdCategoryList").val(-1);
                            $("#ThirdCategoryList1").hide();
                        }

                        // eger bas kataqoruya deyisirse hecneden asli olmayaraq (hamisi 3 ciden basqa cunki mes: heyvan secse ona uygun alt kateqoriya cixmalidir) hide olur ve -1 qiymetini alir


                        //////////////////////// qiymetler ///////////////////////////

                        $(".FourthCategoryList").val(-1)

                        ////////////////// gizlemek /////////////////////////////////


                        $("#FourthCategoryList1").hide();




                    },




                    error: function (error) {
                        console.error(error);
                    }

                });


            }
           

        });

    });

}, 0);












///////////////////////////////////////////////////////////// ucuncu ////////////////////////////////////////////////////




setTimeout(function () {
    $(function () {

        $(".ThirdCategoryList").change(function () {

            $(".FourthCategoryList").empty();

            if ($(".ChooseCategory").val() == 1 || $(".ChooseCategory").val() == 2) { /*ve yaxud catagory adileri 1 dise*/

                $.ajax({
                    url: '/Post/ShowModel',
                    dataType: 'json',
                    data: { id: $(".ThirdCategoryList").val() },
                    success: function (data) {

                        $(".FourthCategoryList").append("<option value='-1'> Model seçin </option>");

                        $.each(data, (_, item) => {
                            $(".FourthCategoryList").append(`<option value= "${item.value}">${item.text}</option>`);

                        });


                        if ($(".ThirdCategoryList").val() > 0) {
                            $("#FourthCategoryList1").show();

                        } else {
                            $(".FourthCategoryList").val(-1);
                            $("#FourthCategoryList1").hide();
                        }

                        // eger bas kataqoruya deyisirse hecneden asli olmayaraq (hamisi 4 ciden basqa cunki mes: heyvan secse ona uygun alt kateqoriya cixmalidir) hide olur ve -1 qiymetini alir


                        //////////////////////// qiymetler ///////////////////////////
                        $(".FourthererCategoryList").val(-1)
  


                        ////////////////// gizlemek /////////////////////////////////
                        $("#FourthCrereategoryList1").hide();




                    },




                    error: function (error) {
                        console.error(error);
                    }

                });




            }
            


        });

    });

}, 0);









