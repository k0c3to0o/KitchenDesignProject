$(document).ready(function(){

    
 $(".dropdown-menu li a").click(function(){
  var selText = $(this).text();
  var attrValue = "btn dropdown-toggle " + $(this).parent().attr("class");
 
  $(this).parents('.btn-group').find('.btn').removeAttr('class').addClass(attrValue);
  $(this).parents('.btn-group').find('.dropdown-toggle').html(selText+' <span class="caret"></span>');
});

    // Slider
    // -----------------------------------------------------------------------------
    $("#mainslider").flexslider({
        animation: "slide",
        slideshow: false, // ***
        useCSS: false,
        controlNav: true,
        animationLoop: false,
        smoothHeight: true
    });

    // Twitter - sidebar
    // -----------------------------------------------------------------------------
    if ($('#twitter').length) {
        $.getJSON('twitter.php?url='+encodeURIComponent('statuses/user_timeline.json?screen_name=dxthemes&count=3'), function(tweets){
            $("#twitter").html(tz_format_twitter(tweets));
        });
    } else { }

    // Twitter - footer
    // -----------------------------------------------------------------------------
    if ($('#twitter-foot').length) {
        $.getJSON('twitter.php?url='+encodeURIComponent('statuses/user_timeline.json?screen_name=dxthemes&count=3'), function(tweets){
            $("#twitter-foot").html(tz_format_twitter(tweets));
        });
    } else { }

    // tooltip
    // -----------------------------------------------------------------------------
    $("a[rel^='tooltip']").tooltip();

    // prettyPhoto
    // -----------------------------------------------------------------------------
    $('a[data-rel]').each(function() {
        $(this).attr('rel', $(this).data('rel'));
    });
    $("a[rel^='prettyPhoto']").prettyPhoto();

    // Main menu
    // -----------------------------------------------------------------------------
    (function() {
		var $menu = $('.navbar-inner ul.nav'),
			optionsList = '<option value="" selected>Menu...</option>';
		$menu.find('li').each(function() {
			var $this   = $(this),
				$anchor = $this.children('a'),
				depth   = $this.parents('ul').length - 1,
				indent  = '';
			if( depth ) {
				while( depth > 0 ) {
					indent += ' - ';
					depth--;
				}
			}
			optionsList += '<option value="' + $anchor.attr('href') + '">' + indent + ' ' + $anchor.text() + '</option>';
		}).end().after('<select class="res-menu">' + optionsList + '</select>');

		$('.res-menu').on('change', function() {
			window.location = $(this).val();
		});
	})();
    
    // Flickr Widget Footer
    // -----------------------------------------------------------------------------
    $('#footer .flickr').jflickrfeed({
        limit: 8,
        qstrings: {
            id: '36621592@N06'
        },
        itemTemplate: ''+
            '<li class="thumbnail">'+
                '<a rel="prettyPhoto[flickr]" href="{{image}}" title="{{title}}">' +
                    '<img src="{{image_s}}" alt="{{title}}" />' +
                    '<span class="frame-overlay"></span>' +
                '</a>' +
            '</li>'
    }, function(data) {
        $("a[rel^='prettyPhoto']").prettyPhoto();
    });

	// Flickr Widget Sidebar
    // -----------------------------------------------------------------------------
    $('#sidebar .sidebar-flickr').jflickrfeed({
		limit: 8,
		qstrings: {
			id: '36621592@N06'
		},
		itemTemplate: ''+
            '<li class="thumbnail">'+
                '<a rel="prettyPhoto[flickr]" href="{{image}}" title="{{title}}">' +
                    '<img src="{{image_s}}" alt="{{title}}" />' +
                    '<span class="frame-overlay"></span>' +
                '</a>' +
            '</li>'
	}, function(data) {
		$("a[rel^='prettyPhoto']").prettyPhoto();
	});

    // Portfolio
    // -----------------------------------------------------------------------------
    $('.prettyPhoto').prettyPhoto();
    // isotope settings
    // cache container
    var $container = $('#portfolio-grid');
    if ($container.length>0) {
        //
        // initialize isotope
        $container.isotope({
            // options...
            itemSelector : 'article',
            resizable: false,
            masonry: { columnWidth: $container.width() / 12 }
            //, layoutMode : 'fitRows'
        });
        //
        // update columnWidth on window resize
        $(window).smartresize(function(){
            $container.isotope({
                // update columnWidth to a percentage of container width
                masonry: { columnWidth: $container.width() / 12 }
            });
        });
        // filter items when filter link is clicked
        $('#filtrable a').click(function(){
            var selector = $(this).attr('data-filter');
            $container.isotope({ filter: selector });
            // mark current li
            $(this).parent().parent().find('.current').removeClass('current');
            $(this).parent().addClass('current');
            return false;
        });
        // add more items to portfolio
        $('.load-more-grid').click(function() {
            var count = $(this).attr('data-count');
            var $newEls = $(fakeElement2.getGroup(count));
            $container.isotope('insert', $newEls, function(){
                relocate();
            });
        });
        // //
        function relocate() {
            setTimeout("$('#portfolio-grid').isotope('reLayout')",1000);
            $('.prettyPhoto').prettyPhoto();
        }
        $(window).load(function(){
            relocate();
        });
        $(window).resize(function(){
            relocate();
        });
    }

    // To Top Button
    // -----------------------------------------------------------------------------
    $(function(){
        $().UItoTop({ easingType: 'easeOutQuart' });
    });

    // Placeholder
    // -----------------------------------------------------------------------------
    $('[placeholder]').focus(function() {
        var input = $(this);
        if (input.val() == input.attr('placeholder')) {
            input.val('');
            input.removeClass('placeholder');
        }
    }).blur(function() {
        var input = $(this);
        if (input.val() == '' || input.val() == input.attr('placeholder')) {
            input.addClass('placeholder');
            input.val(input.attr('placeholder'));
        }
        }).blur().parents('form').submit(function() {
            $(this).find('[placeholder]').each(function() {
                var input = $(this);
                if (input.val() == input.attr('placeholder')) {
                    input.val('');
                }
            })
        });

    // Accordion settings
    // -----------------------------------------------------------------------------
    $(function() {
        $('.accordion').on('show', function (e) {
            $(e.target).prev('.accordion-heading').find('i').removeClass('icon-plus');
            $(e.target).prev('.accordion-heading').find('i').addClass('icon-minus');
            $(e.target).prev('.accordion-heading').removeClass('accordion-close');
            $(e.target).prev('.accordion-heading').addClass('accordion-open');
        });
        $('.accordion').on('hide', function (e) {
            $(e.target).prev('.accordion-heading').find('i').removeClass('icon-minus');
            $(e.target).prev('.accordion-heading').find('i').addClass('icon-plus');
            $(e.target).prev('.accordion-heading').removeClass('accordion-open');
            $(e.target).prev('.accordion-heading').addClass('accordion-close');
        });
    });

});
