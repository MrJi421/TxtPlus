﻿Imports System.Drawing.Printing
Imports System.Windows.Forms

Public Class TxtPlus
    ' Declare a variable to store the file path
    Private filePath As String = ""
    Private myPrintDocument As New PrintDocument()


    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click, NewToolStripButton.Click
        ' Create a new instance of the form
        Dim newForm As New TxtPlus()
        newForm.Show()
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click, OpenToolStripButton.Click
        ' Create and configure the OpenFileDialog
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Text Files|*.txt"
        openFileDialog.Title = "Open a Text File"

        ' Show the OpenFileDialog
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            ' Get the selected file name
            Dim selectedFileName As String = openFileDialog.FileName

            ' Open and read the selected .txt file
            Dim fileContent As String = System.IO.File.ReadAllText(selectedFileName)
            RichTextBox1.Text = fileContent ' Display the content in a RichTextBox (replace RichTextBox1 with your RichTextBox name)

            ' Update the file path for future saves
            filePath = selectedFileName
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click, SaveToolStripButton.Click
        ' Check if a file path is already set
        If Not String.IsNullOrEmpty(filePath) Then
            ' Save the contents to the existing file
            System.IO.File.WriteAllText(filePath, RichTextBox1.Text) ' Assuming RichTextBox1 is your RichTextBox
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

    Private Sub PrintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintToolStripMenuItem.Click, PrintToolStripButton.Click
        Dim printDialog As New PrintDialog()
        If printDialog.ShowDialog() = DialogResult.OK Then
            ' Print your document

        End If
    End Sub

    Private currentPage As Integer = 1
    Private linesPerPage As Integer = 0
    Private linesPrintedSoFar As Integer = 0
    '   Private printContent As String = RichTextBox1.Text

    Private Sub PrintDocument_PrintPage(sender As Object, e As PrintPageEventArgs)

    End Sub


    Private Sub PrintPreviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintPreviewToolStripMenuItem.Click
        Dim printPreviewDialog As New PrintPreviewDialog()

        ' Set your print preview settings
        printPreviewDialog.Document = myPrintDocument

        ' Configure page settings (e.g., page margins, orientation)
        Dim pageSettings As New PageSettings()
        pageSettings.Margins = New Margins(50, 50, 50, 50) ' Adjust margins as needed
        pageSettings.Landscape = False ' Set to True for landscape orientation
        myPrintDocument.DefaultPageSettings = pageSettings

        ' Reset the page counters
        currentPage = 1
        linesPrintedSoFar = 0

        ' Display the print preview dialog
        printPreviewDialog.ShowDialog()
    End Sub


    Private Sub TxtPlus_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ' Check if the main form is closing
        If e.CloseReason = CloseReason.UserClosing Then
            ' Cancel the main form's closing to keep it open
            e.Cancel = True
            ' You can choose to hide the main form instead of closing it
            Me.Hide()
        End If
    End Sub


    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        ' Close other forms as needed
        For Each form As Form In Application.OpenForms
            If form IsNot Me Then
                form.Close()
            End If
        Next

        ' Check if there are no more open forms
        If Application.OpenForms.Count = 0 Then
            ' Exit the application
            Application.Exit()
        End If
    End Sub

    Private Sub UndoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UndoToolStripMenuItem.Click, Undobtn.Click
        ' Undo the last text edit action
        RichTextBox1.Undo()
    End Sub

    Private Sub RedoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RedoToolStripMenuItem.Click, Redobtn.Click
        ' Redo the previously undone text edit action
        RichTextBox1.Redo()
    End Sub

    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click, CutToolStripButton.Click
        ' Cut the selected text
        RichTextBox1.Cut()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click, CopyToolStripButton.Click
        ' Copy the selected text
        RichTextBox1.Copy()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click, PasteToolStripButton.Click
        ' Paste text from the clipboard
        RichTextBox1.Paste()
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        ' Select all the text in the RichTextBox
        RichTextBox1.SelectAll()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox1.Show()
    End Sub

    Private Sub CustomizeToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Customize.ShowDialog()
    End Sub

    Private Sub TxtPlus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RichTextBox1.ForeColor = Color.Black
        enableDisableBtns()
    End Sub


    Public Sub enableDisableBtns()
        If RichTextBox1.SelectionLength > 0 Then
            CutToolStripButton.Enabled = True
            CopyToolStripButton.Enabled = True
            CutToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
        Else
            CutToolStripButton.Enabled = False
            CopyToolStripButton.Enabled = False
            CutToolStripMenuItem.Enabled = False
            CopyToolStripMenuItem.Enabled = False
        End If

        ' Check if there is text in the clipboard that can be pasted
        If Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) Then
            PasteToolStripButton.Enabled = True
            PasteToolStripMenuItem.Enabled = True
        Else
            PasteToolStripButton.Enabled = False
            PasteToolStripMenuItem.Enabled = False
        End If
    End Sub
    Public Function WordCount() As Integer
        ' Split the text into words based on whitespace
        Dim words As String() = RichTextBox1.Text.Split({" "c, ControlChars.Tab, ControlChars.Lf, ControlChars.Cr}, StringSplitOptions.RemoveEmptyEntries)
        Return words.Length
    End Function

    Public Function LetterCount() As Integer
        ' Count the total number of letters in the text
        Dim letterCounter As Integer = 0
        For Each c As Char In RichTextBox1.Text
            If Char.IsLetter(c) Then
                letterCounter += 1
            End If
        Next
        Return letterCounter
    End Function
    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged, RichTextBox1.SelectionChanged
        enableDisableBtns()
        WordCountLbl.Text = WordCount()
        LetterCountLbl.Text = LetterCount()

    End Sub

    Private Sub ToolStripContainer1_TopToolStripPanel_Click(sender As Object, e As EventArgs) Handles ToolStripContainer1.TopToolStripPanel.Click

    End Sub
End Class
