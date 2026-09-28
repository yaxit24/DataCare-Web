<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Print.aspx.vb" Inherits="DcRemainder.Print"  EnableEventValidation="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
      table {
        border-collapse: collapse;
        width: 100%;
      }
      
      th, td {
        padding: 8px;
        text-align: left;
        border-bottom: 1px solid #ddd;
      }
      
      th {
        background-color: #f2f2f2;
      }
      
      .invoice-details {
        margin-bottom: 20px;
      }
      
      .invoice-details h2 {
        margin-top: 0;
        margin-bottom: 10px;
      }
      
      .invoice-details p {
        margin: 0;
      }
      
      .invoice-total {
        margin-top: 20px;
        text-align: right;
      }
      
      .invoice-total p {
        margin: 0;
      }
      
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="invoice-details">
      <h2>Invoice #12345</h2>
      <p>Date: March 31, 2023</p>
      <p>Due Date: April 30, 2023</p>
    </div>
    <table>
      <thead>
        <tr>
          <th>Description</th>
          <th>Quantity</th>
          <th>Price</th>
          <th>Total</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>Product 1</td>
          <td>1</td>
          <td>$100.00</td>
          <td>$100.00</td>
        </tr>
        <tr>
          <td>Product 2</td>
          <td>2</td>
          <td>$50.00</td>
          <td>$100.00</td>
        </tr>
      </tbody>
    </table>
    <div class="invoice-total">
      <p>Subtotal: $200.00</p>
      <p>Tax: $20.00</p>
      <p>Total: $220.00</p>
    </div>
        <asp:Button ID="Button1" runat="server" Text="Button" />
    </form>
</body>
</html>
