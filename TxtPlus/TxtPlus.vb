Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class TxtPlus
    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        Dim newForm As New TxtPlus()

        ' Show the new form
        newForm.Show()
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        ' Create and configure the OpenFileDialog
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Text Files|*.txt"
        openFileDialog.Title = "Open a Text File"

        ' Show the OpenFileDialog
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            ' Get the selected file name
            Dim selectedFileName As String = openFileDialog.FileName

            ' Open and read the selected .txt file, for example, you can display its content in a TextBox
            Dim fileContent As String = System.IO.File.ReadAllText(selectedFileName)
            RichTextBox1.Text = fileContent ' Display the content in a TextBox (replace TextBox1 with your TextBox name)
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        ' Check if a file path is already set
        If Not String.IsNullOrEmpty(filePath) Then
            ' Save the contents to the existing file
            System.IO.File.WriteAllText(filePath, RichTextBox1.Text) ' Assuming TextBox1 is your TextBox
        Else
            ' If there's no file path, open the SaveFileDialog
            Dim saveFileDialog As New SaveFileDialog()
            saveFileDialog.Filter = "Text Files|*.txt"
            saveFileDialog.Title = "Save As"
            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                ' Get the selected file path
                filePath = saveFileDialog.FileName
                ' Save the contents to the selected file
                System.IO.File.WriteAllText(filePath, RichTextBox1.Text)
            End If
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "Text Files|*.txt"
        saveFileDialog.Title = "Save As"
        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            ' Get the selected file path
            filePath = saveFileDialog.FileName
            ' Save the contents to the selected file
            System.IO.File.WriteAllText(filePath, RichTextBox1.Text)
        End If
    End Sub

    Private Sub PrintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintToolStripMenuItem.Click
        Dim printDialog As New PrintDialog()
        If printDialog.ShowDialog() = DialogResult.OK Then
            ' Print your document
        End If
    End Sub

    Private Sub PrintPreviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintPreviewToolStripMenuItem.Click
        Dim printPreviewDialog As New PrintPreviewDialog()
        ' Set your print preview settings
        printPreviewDialog.Document = YourPrintDocument ' Replace with your PrintDocument
        printPreviewDialog.ShowDialog()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        ' Close the application
        Me.Close()
    End Sub
End Class
