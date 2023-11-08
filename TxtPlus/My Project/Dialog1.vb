Imports System.Windows.Forms

Public Class Customize

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        ApplyCustomizationSettings()
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Customize_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Sort and populate FontFamilyBombo ComboBox with available font families
        FontFamilyCombo.Items.AddRange(FontFamily.Families.Select(Function(f) f.Name).OrderBy(Function(name) name).ToArray())

        ' Set default font family
        FontFamilyCombo.SelectedItem = TxtPlus.RichTextBox1.Font.FontFamily.Name

        ' Set default font size
        FontSizeUpDown.Value = CDec(TxtPlus.RichTextBox1.Font.Size)
        'set default font color
        ForeColorbtn.BackColor = Color.Black
    End Sub

    Private Sub Underline_Click(sender As Object, e As EventArgs) Handles Underline.Click
        If Underline.BackColor = Color.LightGray Then
            Underline.BackColor = Nothing
        Else
            Underline.BackColor = Color.LightGray
        End If
    End Sub


    Private Sub Bold_Click(sender As Object, e As EventArgs) Handles Bold.Click
        If Bold.BackColor = Color.LightGray Then
            Bold.BackColor = Nothing
        Else
            Bold.BackColor = Color.LightGray
        End If
    End Sub

    Private Sub Italic_Click(sender As Object, e As EventArgs) Handles Italic.Click
        If Italic.BackColor = Color.LightGray Then
            Italic.BackColor = Nothing
        Else
            Italic.BackColor = Color.LightGray
        End If
    End Sub

    Private Sub ForeColorbtn_Click(sender As Object, e As EventArgs) Handles ForeColorbtn.Click
        If ColorDialog1.ShowDialog = DialogResult.OK Then
            ForeColorbtn.BackColor = ColorDialog1.Color
        End If
    End Sub

    ' Method to apply customization settings to TxtPlus.RichTextBox1
    Private Sub ApplyCustomizationSettings()
        ' Apply font family
        TxtPlus.RichTextBox1.Font = New Font(FontFamilyCombo.SelectedItem.ToString(), CInt(FontSizeUpDown.Value))

        ' Apply formatting options
        TxtPlus.RichTextBox1.SelectionFont = New Font(TxtPlus.RichTextBox1.Font, FontStyle.Regular)
        If Underline.BackColor = Color.LightGray Then
            TxtPlus.RichTextBox1.SelectionFont = New Font(TxtPlus.RichTextBox1.SelectionFont, FontStyle.Underline)
        End If
        If Bold.BackColor = Color.LightGray Then
            TxtPlus.RichTextBox1.SelectionFont = New Font(TxtPlus.RichTextBox1.SelectionFont, FontStyle.Bold)
        End If
        If Italic.BackColor = Color.LightGray Then
            TxtPlus.RichTextBox1.SelectionFont = New Font(TxtPlus.RichTextBox1.SelectionFont, FontStyle.Italic)
        End If

        ' Apply text color
        TxtPlus.RichTextBox1.SelectionColor = ForeColorbtn.BackColor
    End Sub

End Class
