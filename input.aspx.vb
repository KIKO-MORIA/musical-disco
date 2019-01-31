Public Class input
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    Protected Sub BtnTaskSearch_Click(sender As Object,
    ByVal e As EventArgs) Handles btnTaskSearch.Click
        If txtTaskID.Text.Trim.Length = 0 Then
            lblMessage.ForeColor = Drawing.Color.Red
            lblMessage.Text = "タスクを入力してください"
            Exit Sub
        End If

        Dim strSQL As String
        Dim cnn As SqlClient.SqlConnection =
        New SqlClient.SqlConnection("Initial Catalog=Schedule_Data; 
        Data Source=DESKTOP-JVKNKFK\SQLEXPRESS;Integrated Security=SSPI;")
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
            lblMessage.ForeColor = Drawing.Color.Red
            lblMessage.Text = "データベースアクセスに失敗しました"
            GoTo LBL_Exit
        End Try
        If dsDataSet.Tables(0).Rows.Count > 0 Then
            With dsDataSet.Tables(0).Rows(0)
                txtTaskName.Text = .Item("タスク名")
            End With
        Else
            lblMessage.ForeColor = Drawing.Color.Red
            lblMessage.Text = "タスクが登録されていません"
        End If
LBL_Exit:
        cnn = Nothing
        sqlcmdSelect = Nothing
        adpt = Nothing
        dsDataSet = Nothing
    End Sub

    Protected Sub txtTaskID_TextChanged(sender As Object, e As EventArgs) Handles txtTaskID.TextChanged

    End Sub

    Protected Sub BtnAddTask_Click(sender As Object,
    ByVal e As System.EventArgs) Handles btnAddTask.Click
        lblMessage.ForeColor = Drawing.Color.Red
        If txtTaskID.Text.Trim = "" Or
           txtTaskName.Text.Trim = "" Then
            lblMessage.Text = "タスクを入力してください"
            Exit Sub
        End If
        If txtDate.Text.Trim = "" Or IsDate(txtDate.Text.Trim) = False Then
            lblMessage.Text = "日付を入力してください"
            Exit Sub
        End If
        If txtTimeS.Text.Trim = "" Or txtTimeE.Text.Trim = "" Then
            lblMessage.Text = "時間を入力してください"
            Exit Sub
        End If

        Dim strSQL As String
        Dim cnn As SqlClient.SqlConnection =
        New SqlClient.SqlConnection("Initial Catalog=Schedule_Data; 
        Data Source=DESKTOP-JVKNKFK\SQLEXPRESS;Integrated Security=SSPI;")
        cnn.Open()

        Dim execmd As New SqlClient.SqlCommand
        Dim tran As SqlClient.SqlTransaction
        tran = cnn.BeginTransaction(IsolationLevel.Serializable)
        execmd.Connection = cnn
        execmd.Transaction = tran
        Try
            strSQL = "INSERT INTO スケジュールデータ(作業日, 作業時間_始, 作業時間_終, タスクコード) " &
                     "VALUES (" & "'" & CDate(txtDate.Text.Trim) & "'," &
                                  "'" & txtTimeS.Text.Trim & "'," &
                                  "'" & txtTimeE.Text.Trim & "'," &
                                  "'" & txtTaskID.Text.Trim & "');"

            execmd.CommandText = strSQL
            execmd.ExecuteNonQuery()
            tran.Commit()
            cnn.Close()
        Catch ex As Exception
            tran.Rollback()
            cnn.Close()
            Exit Sub
        End Try

        lblMessage.ForeColor = Drawing.Color.Blue
        lblMessage.Text = "登録しました"

    End Sub

    Protected Sub txtTimeS_TextChanged(sender As Object, e As EventArgs) Handles txtTimeS.TextChanged

    End Sub
End Class