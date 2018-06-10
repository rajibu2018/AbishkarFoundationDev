<?php
require_once('class.phpmailer.php'); 
{
    $Content = nl2br($_REQUEST['Description']);
    $strMailbody = "<table width=700 border=0 cellspacing=1 cellpadding=1 align=default><tr><td align=left>
    <tr><td><font face=Verdana size=2><b>Dear  Webmaster,</b><br><br/>A visitor @ 'ABISKAR FOUNDATION' has filled up the web contact us form.<br>
    The details of the visitor is as follows:-</font><br><br>
    </td></tr></font></b></td></tr></table>
    <table width=600 border=0 cellspacing=1 cellpadding=1 style='border: 1px solid black;'>

    <tr><td width=150><font face=Verdana size=2 color=#2B518B>Name</font></td>
    <td width=500><font face=Verdana size=2>$_REQUEST[Name]&nbsp;</font></td></tr>
    <tr><td><font face=Verdana size=2 color=#2B518B>Email</font></td>
    <td><font face=Verdana size=2>$_REQUEST[Email]&nbsp;</font></td></tr>
    <tr><td valign=top><font face=Verdana size=2 color=#2B518B>Message&nbsp;&nbsp;&nbsp;</font></td>
    <td><font face=Verdana size=2>$Content &nbsp;</font></td></tr></table>
    </font></b></td></tr></table><br/><br/><font face=Verdana size=2>Regards,<br/>ABISKAR FOUNDATION<br/></font>";

    $mail = new PHPMailer(true);
   // $mail->AddAddress('dibakarghosh21@gmail.com', '');
    $mail->AddAddress('info@abiskarfoundation.com', '');
    //if($FeedbackCc != "")
//        $mail->AddCC($FeedbackCc, '');
//    if($FeedbackBcc != "")
//        $mail->AddBCC($FeedbackBcc, '');
    $mail->SetFrom($_REQUEST['Email'], '');
    $mail->Subject = "Website Contact Us Form @ 'Abiskar Foundation'";
    $mail->MsgHTML($strMailbody);
    $ServerName = $_SERVER['SERVER_NAME'];
    if(strstr($ServerName, "localhost")) {}
    else {$mail->Send();}       

}
?>
