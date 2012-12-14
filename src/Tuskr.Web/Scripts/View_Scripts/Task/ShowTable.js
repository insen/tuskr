window.tuskr = window.tuskr || {};

window.tuskr.ShowTable = function() {
    this.init = function() {
        $('.task-gp-hdr').click(function() {
            var header = $(this).closest('tr');
            var elements = $('tbody [data-group-reference=' + header.attr('id') + ']');

            elements.toggle('toggle');
            return false;
        });
    };
};

$(document).ready(function() {
    var module = new window.tuskr.ShowTable();
    module.init();
});
