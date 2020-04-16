
$(document).ready(function () {

    $('.select2-ajax').select2({
        ajax: {
            //url: '@Url.Action("Find","Home")',
            url: '/Admin/User/Find',
            dataType: 'json'
        }
    });







});




//function formatRepo(repo) {
//    if (repo.loading) return repo.text;

//    var markup = '<div class="clearfix">' +
//        '<div class="col-sm-1">' +
//        '<img src="/images/' + repo.imageUrl + '" style="width:42px;height:42px" />' +
//        '</div>' +
//        '<div clas="col-sm-10">' +
//            '<div class="clearfix">' +
//            '<div class="col-sm-6">' + repo.name + '</div>' +
//        '<div class="col-sm-3"><i class="fa fa-code-fork"></i> ' + repo.productID + '</div>' +
//        '<div class="col-sm-2"><i class="fa fa-star"></i> ' + repo.productID + '</div>' +
//        '</div>';

//    if (repo.description) {
//        markup += '<div>' + repo.description + '</div>';
//    }

//    markup += '</div></div>';

//    return markup;
//}

//function formatRepoSelection(repo) {
//    return repo.name /*|| repo.text;*/
//}

//$(document).ready(function () {

//    $(".select2-ajax-template").select2({
//        ajax: {
//            url: '/Home/Find2',
//            dataType: 'json',
//            delay: 250,
//            data: function (params) {
//                return {
//                    q: params.term, // search term
//                    page: params.page
//                };
//            },
//            processResults: function (data, page) {
//                // parse the results into the format expected by Select2.
//                // since we are using custom formatting functions we do not need to
//                // alter the remote JSON data
//                return {
//                    results: data.items
//                };
//            },
//            cache: true
//        },
//        escapeMarkup: function (markup) { return markup; }, // let our custom formatter work
//        minimumInputLength: 2,
//        templateResult: formatRepo, // omitted for brevity, see the source of this page
//        templateSelection: formatRepoSelection // omitted for brevity, see the source of this page
      


//    });
//});  













