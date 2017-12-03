var Optics = Optics || {};

// Auto-initialization of modules
jQuery(function () {
    for (var key in Optics) {
        if (typeof Optics[key]._initialize == 'function') {
            Optics[key]._initialize.call(Optics[key]);
        }
    }
});