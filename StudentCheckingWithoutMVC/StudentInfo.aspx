<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentInfo.aspx.cs" Inherits="StudentCheckingWithoutMVC.StudentInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  <meta charset="utf-8">
  <title>StudentDetails</title>
  <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
  <base href="/">

  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="icon" type="image/x-icon" href="favicon.ico">
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div style="width:100%;text-align:center">

  <h1> Student Detail System</h1>
  
  </div>
  
  <div style="width:100%;align-content: center">
   <asp:HiddenField runat="server" ID="hid_StudentID" />
  <div style="margin:10px;display: inline-block;">Name : <asp:TextBox runat="server" ID="txtName" class="form-control"></asp:TextBox>   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="Enter  Name"
                                            CssClass="lable-Error"></asp:RequiredFieldValidator></div>
  
  <div style="margin:10px;display: inline-block;"> Address : <asp:TextBox runat="server" ID="txtAddress" class="form-control"></asp:TextBox>   </div>
  
  <div style="margin:10px;display: inline-block;"> Telephone : <asp:TextBox runat="server" ID="txtTelephone" class="form-control"></asp:TextBox></div>
  
  
  
  <div style="margin:10px;display: inline-block;"> Standard : <asp:TextBox runat="server" ID="txtStandard" class="form-control"></asp:TextBox></div>
  
  <div style="margin:10px;display: inline-block;" > Roll Number : <asp:TextBox runat="server" ID="txtRollNumber" class="form-control"></asp:TextBox></div>
  
  </div>
  
  <div class="w3-cell-row w3-center w3-padding">
  
  
  
  <asp:Button ID="Button1" runat="server" name="submit" Text="Insert" class="w3-btn w3-blue w3-border w3-margin" type="submit" value="Insert" OnClick="Insert_Click"/>
  
  <asp:Button ID="update" runat="server" name="submit" Text="Update" class="w3-btn w3-blue w3-border w3-margin" type="submit" value="Update" OnClick="update_Click"/>
  
  <asp:Button ID="delete" runat="server" name="submit" Text="Delete" class="w3-btn w3-blue w3-border w3-margin" type="submit" value="Delete" OnClick="delete_Click"/>
  
  </div>
  
  
  <asp:GridView ClientIDMode="Static" ID="datatable1" runat="server" AutoGenerateColumns="False" CssClass="w3-table-all w3-small" DataKeyNames="student_id"
                        CellPadding="0" border="0" class="datatable table table-striped table-bordered table-hover" OnRowDataBound="datatable1_RowDataBound" >
                        <Columns>
                            <asp:BoundField DataField="student_id" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" HeaderText="Category Code" SortExpression="Customer_Cd" />
                            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                            <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                            <asp:BoundField DataField="Telephone" HeaderText="Telephone" SortExpression="Telephone" />
                                <asp:BoundField DataField="Roll_Number" HeaderText="Roll Number"  />
                                <asp:BoundField DataField="Standard" HeaderText="Standard" />
                            
                                                    </Columns>
                    </asp:GridView>
  
 
    </div>
    </form>
</body>
</html>
