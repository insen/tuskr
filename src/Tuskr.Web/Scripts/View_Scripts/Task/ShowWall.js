window.tuskr = window.tuskr || {};

window.tuskr.ShowWall = function () {
    var srcContainer = {};

    var onFail = function(ev, ui) {
        alert('error');
//        ui.draggable.animate(uipos, "slow");
        srcContainer.append(ui.draggable);
    };

    var onPass = function (ui, sink) {
        sink.append(ui.draggable);
    };

    var tryUpdate = function (ui, sink, ev, pass, fail) {
        var draggedId = $(ui.draggable).attr('id');
        var droppedStatus = $('em', sink).text();
        var data = '{id:' + draggedId + ',status=' + droppedStatus + '}';

        $.ajax({
            url: '/Task/Edit',
            type: 'post',
            data: data,
            success: pass(ui, sink),
            failure: fail(ev, ui)
        });
        
    };
    
    var isAllowed = function(ui, sink) {
        var from = $('div.t-status', ui.draggable).text();
        var to = $('em', sink).text();

        if (from == 'Done') return false;
        if (from == 'Undefined' && to == 'Done') return false;
        return true;
    };

    this.init = function () {
        $('div.task-wall-item').each(function() {
            $(this).draggable({
                revert: true,
                start: function (ev, ui) {
                    srcContainer = $(ui.helper).parents().closest('div.lane-label');
                }
            });
        });

        $('div.task-wall-container').each(function () {
            $(this).droppable({
                //tolerance: 'touch',
                drop: function (ev, ui) {
                    var sink = $(this);
                    if (isAllowed(ui, sink)) {
                        tryUpdate(ui, sink, ev, onPass, onFail);
                    } else {
                        alert("transition not allowed");
                    }
                    return true;
                }
            });
        });
    };

    return this;
};

$(document).ready(function () {
    var mod = new window.tuskr.ShowWall();
    mod.init();
});

