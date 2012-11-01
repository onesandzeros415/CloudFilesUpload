<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="CloudFilesUpload._default" %>

<!DOCTYPE html>


<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <title>CloudFiles 3.0 Upload Test - OpenSwift Version</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="">

    <!-- Le styles -->
    <link href="../assets/css/bootstrap.css" rel="stylesheet">
    <style>
        body {
            padding-top: 60px; /* 60px to make the container go all the way to the bottom of the topbar */
        }
    </style>
    <link href="../assets/css/bootstrap-responsive.css" rel="stylesheet">

    <!-- Le HTML5 shim, for IE6-8 support of HTML5 elements -->
    <!--[if lt IE 9]>
      <script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
    <![endif]-->

    <!-- Le fav and touch icons -->
    <link rel="shortcut icon" href="../assets/ico/favicon.ico">
    <link rel="apple-touch-icon-precomposed" sizes="144x144" href="../assets/ico/apple-touch-icon-144-precomposed.png">
    <link rel="apple-touch-icon-precomposed" sizes="114x114" href="../assets/ico/apple-touch-icon-114-precomposed.png">
    <link rel="apple-touch-icon-precomposed" sizes="72x72" href="../assets/ico/apple-touch-icon-72-precomposed.png">
    <link rel="apple-touch-icon-precomposed" href="../assets/ico/apple-touch-icon-57-precomposed.png">
</head>

<body>
    <form runat="server">
        <div class="navbar navbar-inverse navbar-fixed-top">
            <div class="navbar-inner">
                <div class="container">
                    <a class="btn btn-navbar" data-toggle="collapse" data-target=".nav-collapse">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </a>
                    <a class="brand" href="#">CloudFiles OpenSwift V3 Upload Example</a>
                    <div class="nav-collapse collapse">
                        <ul class="nav">
                            <li class="active"><a href="#">Home</a></li>
                            <li><a href="#about">About</a></li>
                            <li><a href="#contact">Contact</a></li>
                        </ul>
                    </div>
                    <!--/.nav-collapse -->
                </div>
            </div>
        </div>

        <div class="container">

            <h1>Instructions:</h1>
            <p>
                Please enter your Username, APIKey, and Container to upload to.<br>
                Once you have successfully entered this information please be sure<br />
                to select true of false for service net and then click upload.<br />
                <br />

                When uploading a file it's temporarily stored in the temp directory so<br />
                be sure to add your impersonation to your web.config so the file system
                <br />
                can upload the file.
                <br />
                <br />
            </p>
            <br />
            Username:
            <br />
            <asp:TextBox ID="CFUsernameText" runat="server"></asp:TextBox>
            <br />
            APIKey:
            <br />
            <asp:TextBox ID="CFApiKeyText" TextMode="Password" runat="server"></asp:TextBox>
            <br />
            Container To Upload To:
            <br />
            <asp:TextBox ID="CFContainerText" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="ListContentsBtn" runat="server" CssClass="btn-primary" OnClick="ListContainerContents_Click" Text="List Contents" />
            <br />
            <br />
            <asp:GridView ID="CFResultsGrid" runat="server"></asp:GridView>
            <br />
            <div>
                ServiceNet:
                <br />
                <div style="width: 40px; float: left;">
                    <asp:CheckBox ID="SnetTrue" Text="True" value="True" runat="server" />
                </div>
                <div style="width: 40px; float: left;">
                    <br />
                    Or
                </div>
                <div style="width: 40px; float: left;">
                    <asp:CheckBox ID="SnetFalse" Text="False" value="False" runat="server" />
                </div>
                <div style="clear: both;">
                </div>
                <br />
                <br />
            </div>
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Button ID="btnUpload" runat="server" CssClass="btn-primary" Text="Upload" OnClick="btnUpload_Click"
                OnClientClick="return CallJS('Demo()');" />
            <br />
            <br />
            <br />
            <asp:Label ID="Error" ForeColor="Red" runat="server"></asp:Label>
            <br />
        </div>
        <!-- /container -->

        <!-- Le javascript ================================================== -->
        <!-- Placed at the end of the document so the pages load faster -->
        <script src="../assets/js/jquery.js"></script>
        <script src="../assets/js/bootstrap-transition.js"></script>
        <script src="../assets/js/bootstrap-alert.js"></script>
        <script src="../assets/js/bootstrap-modal.js"></script>
        <script src="../assets/js/bootstrap-dropdown.js"></script>
        <script src="../assets/js/bootstrap-scrollspy.js"></script>
        <script src="../assets/js/bootstrap-tab.js"></script>
        <script src="../assets/js/bootstrap-tooltip.js"></script>
        <script src="../assets/js/bootstrap-popover.js"></script>
        <script src="../assets/js/bootstrap-button.js"></script>
        <script src="../assets/js/bootstrap-collapse.js"></script>
        <script src="../assets/js/bootstrap-carousel.js"></script>
        <script src="../assets/js/bootstrap-typeahead.js"></script>
    </form>
</body>
</html>

