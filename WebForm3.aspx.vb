Public Class WebForm3
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles txtTaskName.TextChanged

    End Sub

    Protected Sub RptSchedule_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles rptSchedule.ItemCommand

    End Sub

    Protected Sub btnSelect_Click(sender As Object, e As System.EventArgs) Handles btnSelect.Click
        calResult.Visible = False
        rptSchedule.Visible = False

        txtTaskName.Text = ""
        If txtTaskID.Text.Trim.Length = 0 Then
            Exit Sub
        End If
        Dim strSQL As String
        Dim cnn As SqlClient.SqlConnection =
        New SqlClient.SqlConnection("Initial Catalog=Schedule_Data; 
        Data Source=DESKTOP-JVKNKFK\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;")
        Dim sqlcmdSelect As SqlClient.SqlCommand = New SqlClient.SqlCommand()
        Dim adpt As SqlClient.SqlDataAdapter = New SqlClient.SqlDataAdapter()
        Dim dsDataSet As DataSet = New DataSet

        sqlcmdSelect.Connection = cnn
        sqlcmdSelect.CommandTimeout = 15

        strSQL = "SELECT * FROM タスクマスタ WHERE タスクコード='" & txtTaskID.Text.Trim & "';"
        sqlcmdSelect.CommandText = strSQL
        adpt.SelectCommand = sqlcmdSelect
        Try
            adpt.Fill(dsDataSet)
        Catch ex As Exception
            cnn.Close()
            GoTo LBL_Exit
        End Try
        If dsDataSet.Tables(0).Rows.Count > 0 Then
            With dsDataSet.Tables(0).Rows(0)
                txtTaskName.Text = .Item("タスク名")
            End With
        End If
LBL_Exit:
        cnn = Nothing
        sqlcmdselect = Nothing
        adpt = Nothing
        dsDataSet = Nothing
    End Sub

    Protected Sub btnSearch_Click(sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        calResult.Visible = True
        rptSchedule.Visible = True
    End Sub

    Protected Sub Cal_DayRender(sender As Object, ByVal e As DayRenderEventArgs)
        Dim objDb As New SqlClient.SqlConnection("Initial Catalog=Schedule_Data; 
        Data Source=DESKTOP-JVKNKFK\SQLEXPRESS;Integrated Security=SSPI;")

        Dim strSQL As String
        strSQL = "SELECT COUNT(*) " &
                 "FROM  スケジュールデータ " &
                 "WHERE 作業日=@sdate " &
                 "AND タスクコード='" & txtTaskID.Text.Trim & "';"
        Dim objCom As New SqlClient.SqlCommand(strSQL, objDb)
        objCom.Parameters.Add("@sdate", SqlDbType.DateTime)
        objCom.Parameters("@sdate").Value = e.Day.Date
        objDb.Open()
        Dim objDr As SqlClient.SqlDataReader = objCom.ExecuteReader()

        Do While objDr.Read()
            If objDr.GetInt32(0) = 0 Then
                e.Cell.Controls.Add(New LiteralControl("<br /><br /><br />"))
            Else
                e.Cell.Controls.Add(New LiteralControl("<br /><br />" & String.Format("{0}件", objDr.GetInt32(0))))
                e.Cell.BackColor = Drawing.Color.Lavender
            End If
        Loop
        objDb.Close()
    End Sub

    Protected Sub calResult_SelectionChanged(sender As Object, ByVal e As EventArgs)
        Dim db As New SqlClient.SqlConnection("Initial Catalog=Schedule_Data;
        Data Source=DESKTOP-JVKNKFK\SQLEXPRESS;Integrated Security=SSPI;")
        Dim strSQL As String
        strSQL = "SELECT スケジュールデータ.作業時間_始 AS STime, " &
                        "スケジュールデータ.作業時間_終 AS ETime, " &
                        "スケジュールデータ.タスクコード, " &
                        "タスクマスタ.タスク名 AS TaskName " &
                 "FROM スケジュールデータ " &
                 "LEFT JOIN タスクマスタ ON スケジュールデータ.タスクコード=タスクマスタ.タスクコード " &
                 "WHERE スケジュールデータ.作業日=@sdate " &
                 "ORDER BY STime ASC;"
        Dim objCom As New SqlClient.SqlCommand(strSQL, db)
        objCom.Parameters.Add("@sdate", SqlDbType.DateTime)
        objCom.Parameters("@sdate").Value = calResult.SelectedDate
        db.Open()
        rptSchedule.DataSource = objCom.ExecuteReader()
        rptSchedule.DataBind()
        db.Close()
    End Sub
End Class