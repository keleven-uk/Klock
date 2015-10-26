Imports System.Collections
Imports System.Windows.Forms

Public Class ListViewColumnSorter
    Implements System.Collections.IComparer

    Private ColumnToSort As Integer
    Private OrderOfSort As SortOrder
    Private ObjectCompare As CaseInsensitiveComparer

    Public Sub New()
        ' Initialize the column to '0'.
        ColumnToSort = 0

        ' Initialize the sort order to 'none'.
        OrderOfSort = SortOrder.None

        ' Initialize the CaseInsensitiveComparer object.
        ObjectCompare = New CaseInsensitiveComparer()
    End Sub

    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
        Dim compareResult As Integer
        Dim listviewX As ListViewItem
        Dim listviewY As ListViewItem

        ' Cast the objects to be compared to ListViewItem objects.
        listviewX = CType(x, ListViewItem)
        listviewY = CType(y, ListViewItem)

        ' Compare the two items.
        Select Case frmNECAudit.tabCntrlAudit.SelectedIndex
            Case 0, 1, 2, 3
                compareResult = ObjectCompare.Compare(listviewX.SubItems(ColumnToSort).Text, listviewY.SubItems(ColumnToSort).Text)
            Case 4
                Select Case ColumnToSort
                    Case 0, 1, 2, 4, 8, 9               '   compare as strings
                        compareResult = ObjectCompare.Compare(listviewX.SubItems(ColumnToSort).Text, listviewY.SubItems(ColumnToSort).Text)
                    Case 3                              '   compare as dates
                        compareResult = ObjectCompare.Compare(DateTime.Parse(listviewX.SubItems(ColumnToSort).Text), DateTime.Parse(listviewY.SubItems(ColumnToSort).Text))
                    Case 5, 6, 7                           '      compare as numbers
                        compareResult = ObjectCompare.Compare(Val(listviewX.SubItems(ColumnToSort).Text), Val(listviewY.SubItems(ColumnToSort).Text))
                End Select
        End Select

        ' Calculate the correct return value based on the object comparison.
        If (OrderOfSort = SortOrder.Ascending) Then
            ' Ascending sort is selected, return typical result of compare operation.
            Return compareResult
        ElseIf (OrderOfSort = SortOrder.Descending) Then
            ' Descending sort is selected, return negative result of compare operation.
            Return (-compareResult)
        Else
            ' Return '0' to indicate that they are equal.
            Return 0
        End If
    End Function

    Public Property SortColumn() As Integer
        Set(ByVal Value As Integer)
            ColumnToSort = Value
        End Set

        Get
            Return ColumnToSort
        End Get
    End Property

    Public Property Order() As SortOrder
        Set(ByVal Value As SortOrder)
            OrderOfSort = Value
        End Set

        Get
            Return OrderOfSort
        End Get
    End Property
End Class



