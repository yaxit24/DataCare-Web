<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="OR_ITEMSELECT.aspx.vb" Inherits="DcRemainder.OR_ITEMSELECT" %>

<!DOCTYPE html>

<html>
<head>
    <title>QR Code Reader using Instascan</title>
   <script type="text/javascript" src="https://unpkg.com/@zxing/library@latest"></script>
     <%--<script language="javascript" type="text/javascript">
         var redirectTimerId = 0;
         function closeWindow() {
             var myWindow = window.open("", "_self");
             setTimeout(function () { myWindow.close(); }, 10000);
         }
         
         function stopRedirect() {
             window.clearTimeout(redirectTimerId);
             window.opener = self;
             window.close('', '_parent', '');
         }

         function redirect() {
             window.opener = self;
             window.top.close();
             //window.close();  //location = 'TR_WHSALE.aspx';
         }
     </script>--%>
    
   
</head>
<body runat="server">
    <form runat="server">
    <video id="webcam-preview"></video>
    <asp:TextBox ID="QRresult" onkeydown="closeWindowe()" runat="server"></asp:TextBox>
    
    <asp:Button ID="QRSAND" runat="server" Text="Button" />
    
    <%--<p id="result"></p>--%>
    </form>
<script>
    const codeReader = new ZXing.BrowserQRCodeReader();
   
    codeReader.decodeFromVideoDevice(null, 'webcam-preview', (result, err) => {
        if (result) {
            var myWindow = window.open("", "_self");
            
            // properly decoded qr code
            console.log('Found QR code!', result)
            let x = result
            //document.getElementById('result').textContent = x;       //result.text
            document.getElementById('QRresult').value = x;



            //var span_Text = document.getElementById("span_Id").value;
            //document.getElementById('QRresult').value = span_Text
            document.getElementById("<%= QRSAND.ClientID %>").click();
            //myWindow.close();
        }

        if (err) {
            // As long as this error belongs into one of the following categories
            // the code reader is going to continue as excepted. Any other error
            // will stop the decoding loop.
            //
            // Excepted Exceptions:
            //
            //  - NotFoundException
            //  - ChecksumException
            //  - FormatException

            if (err instanceof ZXing.NotFoundException) {
                console.log('No QR code found.')
            }

            if (err instanceof ZXing.ChecksumException) {
                console.log('A code was found, but it\'s read value was not valid.')
            }

            if (err instanceof ZXing.FormatException) {
                console.log('A code was found, but it was in a invalid format.')
            }
        }
    })
</script>
    
</body>
</html>
