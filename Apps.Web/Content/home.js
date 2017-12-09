
      $(function () {
          $('#tab_menu-tabrefresh').click(function () {
              /*fresh tab */
              var url = $(".tabs-panels .panel").eq($('.tabs-selected').index()).find("iframe").attr("src");
              $(".tabs-panels .panel").eq($('.tabs-selected').index()).find("iframe").attr("src", url);
          });
          //Open new tab
          $('#tab_menu-openFrame').click(function () {
              var url = $(".tabs-panels .panel").eq($('.tabs-selected').index()).find("iframe").attr("src");
              window.open(url);
          });
          //Close current tab
          $('#tab_menu-tabclose').click(function () {
              var currtab_title = $('.tabs-selected .tabs-inner span').text();
              $('#mainTab').tabs('close', currtab_title);
              if ($(".tabs li").length == 0) {
                  //open menu
                  $(".layout-button-right").trigger("click");
              }
          });
          //Close All
          $('#tab_menu-tabcloseall').click(function () {
              $('.tabs-inner span').each(function (i, n) {
                  if ($(this).parent().next().is('.tabs-close')) {
                      var t = $(n).text();
                      $('#mainTab').tabs('close', t);
                  }
              });
              //open menu
              $(".layout-button-right").trigger("click");
          });
          //Close all otherTAB
          $('#tab_menu-tabcloseother').click(function () {
              var currtab_title = $('.tabs-selected .tabs-inner span').text();
              $('.tabs-inner span').each(function (i, n) {
                  if ($(this).parent().next().is('.tabs-close')) {
                      var t = $(n).text();
                      if (t != currtab_title)
                          $('#mainTab').tabs('close', t);
                  }
              });
          });
          //Close right TAB
          $('#tab_menu-tabcloseright').click(function () {
              var nextall = $('.tabs-selected').nextAll();
              if (nextall.length == 0) {
                  $.messager.alert('Warning', 'No Tabs!', 'warning');
                  return false;
              }
              nextall.each(function (i, n) {
                  if ($('a.tabs-close', $(n)).length > 0) {
                      var t = $('a:eq(0) span', $(n)).text();
                      $('#mainTab').tabs('close', t);
                  }
              });
              return false;
          });
          //Close left TAB
          $('#tab_menu-tabcloseleft').click(function () {

              var prevall = $('.tabs-selected').prevAll();
              if (prevall.length == 0) {
                  $.messager.alert('Warning', 'No Tabs!', 'warning');
                  return false;
              }
              prevall.each(function (i, n) {
                  if ($('a.tabs-close', $(n)).length > 0) {
                      var t = $('a:eq(0) span', $(n)).text();
                      $('#mainTab').tabs('close', t);
                  }
              });
              return false;
          });

      });


function addTab(subtitle, url, icon) {
    if (!$("#mainTab").tabs('exists', subtitle)) {
        $("#mainTab").tabs('add', {
            title: subtitle,
            content: createFrame(url),
            closable: true,
            icon: icon
        });
    } else {
        $("#mainTab").tabs('select', subtitle);
        $("#tab_menu-tabrefresh").trigger("click");
    }
    $(".layout-button-left").trigger("click");
    //tabClose();
}
function createFrame(url) {
    var s = '<iframe frameborder="0" src="' + url + '" scrolling="auto" style="width:100%; height:99%"></iframe>';
    return s;
}


    $(function () {
        $(".ui-skin-nav .li-skinitem span").click(function () {
            var theme = $(this).attr("rel");
            $.messager.confirm('alert', 'Changeing skin, reloading！', function (r) {
                if (r) {
                    $.post("../../Home/SetThemes", { value: theme }, function (data) { window.location.reload(); }, "json");
                }
            });
        });
    });
