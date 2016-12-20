<%@ Page Title="" Language="C#" MasterPageFile="~/shared/Site.master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="lks.Mall.WebApp.member.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../assets/lib/jqueryui/jquery-ui.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container-fluid">
        <div class="row-fluid">
            <div class="span8">
                <span class="label"><%=CurrentUser.LoginId.ToString() %>欢迎你</span>
            </div>
            <div class="span4">
                <img alt="140x140" src="#" id="img_cut" class="img-rounded" />
            </div>


            <div id="content">
                <div id="swfu_container" style="margin: 0px 10px;">
                    <div>
                        <span id="spanButtonPlaceholder"></span>
                    </div>
                    <div id="divFileProgressContainer" style="height: 75px;"></div>
                    <div id="thumbnails">
                        <div id="cut" style="width: 100px; height: 100px; border: 1px solid blue"></div>
                    </div>
                    <input type="button" value="cut" id="btn_cut" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
    <script src="../assets/lib/jqueryui/jquery-ui.min.js"></script>
    <script src="/assets/lib/swfupload/swfupload.js"></script>
    <script src="/assets/lib/swfupload/handlers.js"></script>
    <script type="text/javascript">
        var swfu;
        var imgsrc;
        window.onload = function () {
            swfu = new SWFUpload({
                // Backend Settings
                upload_url: "/handler/FileUploadHandler.ashx?action=Upload",
                post_params: {
                    "ASPSESSID": "<%=Session.SessionID %>"
                },

                // File Upload Settings
                file_size_limit: "2 MB",
                file_types: "*.jpg",
                file_types_description: "JPG Images",
                file_upload_limit: "0",    // Zero means unlimited

                // Event Handler Settings - these functions as defined in Handlers.js
                //  The handlers are not part of SWFUpload but are part of my website and control how
                //  my website reacts to the SWFUpload events.
                file_queue_error_handler: fileQueueError,
                file_dialog_complete_handler: fileDialogComplete,
                upload_progress_handler: uploadProgress,
                upload_error_handler: uploadError,
                upload_success_handler: function (file, serverData) {
                    console.log(serverData);
                    var vpath = serverData.substr(1);
                    var img = new Image();
                    imgsrc = vpath;
                    img.src = imgsrc;

                    img.onload = function () {
                        $('#thumbnails').css('background-image', 'url(' + vpath + ')')
                                                           .css('width', img.width)
                                                           .css('height', img.height);
                        $("#cut").resizable({ containment: '#thumbnails' }).draggable({ containment: '#thumbnails' });
                    }

                },
                upload_complete_handler: uploadComplete,

                // Button settings
                button_image_url: "/assets/lib/swfupload/images/XPButtonNoText_160x22.png",
                button_placeholder_id: "spanButtonPlaceholder",
                button_width: 160,
                button_height: 22,
                button_text: '<span class="button">Select Images <span class="buttonSmall">(2 MB Max)</span></span>',
                button_text_style: '.button { font-family: Helvetica, Arial, sans-serif; font-size: 14pt; } .buttonSmall { font-size: 10pt; }',
                button_text_top_padding: 1,
                button_text_left_padding: 5,

                // Flash Settings
                flash_url: "/assets/lib/swfupload/swfupload.swf",	// Relative to this file

                custom_settings: {
                    upload_target: "divFileProgressContainer"
                },

                // Debug Settings
                debug: false
            });
        }

        $("#btn_cut").click(function () {
            var $cut = $('#cut');
            //大小
            var width = $cut.width();
            var height = $cut.height();
            //位置
            var top = parseInt($cut.css('top'));
            var left = parseInt($cut.css('left'));

            console.log(width + "dd" + height);
            console.log(top + "dd" + left);

            $.post("/handler/FileUploadHandler.ashx?action=Cut", {
                width: width,
                height: height,
                top: top,
                left: left,
                filePath: imgsrc
            }, function (url) {
                $('#img_cut').attr('src', url);
            });
        });
    </script>
</asp:Content>
