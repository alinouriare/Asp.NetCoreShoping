function myFunction() {
    var input = $("#mysearch");

    var filter = $("#mysearch").val().toLowerCase();
    var ul = $("#myUL");
    var li = ul.children('li');
    ul.children().remove();
    $.ajax({


        url: '/Home/Search',
        data: { category: filter },
        type: 'post',
        success: function (response) {
            console.log(response);
          
            $.each(response, function (i, data) {


                ul.append('<li ><a href="/Home/Index/?category=' + data.category + '">' + data.name + '</a></li>');

                //if (input.fadeOut()) {
                //    ul.children("li").style.display = "none";
                //}
              
            });
        },
           error: function () {
            alert("error");
        }
    });
}