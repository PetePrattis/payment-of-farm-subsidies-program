Sub Main()
        Dim region_code As Single
        Dim product_name As String
        Dim acres As Integer
        Dim farms As Integer

        Dim average_farm_size As Integer
        Dim subsidy As Integer

        FileOpen(1, "C:\temp\RESULTS.txt", OpenMode.Append)

        Do
            region_code = InputBox("Enter a region code (1-13) or 0 to exit")

            If region_code <> 0 Then
                product_name = InputBox("Give a product name")
                acres = InputBox("Give cultivated acres of farms")
                farms = InputBox("Give number of farms")

                average_farm_size = acres / farms

                If average_farm_size < 50 Then
                    subsidy = acres * 120
                ElseIf average_farm_size < 100 Then
                    subsidy = acres * 100
                ElseIf average_farm_size >= 100 Then
                    subsidy = acres * 50
                End If

                MsgBox("The subsidy for the product " & product_name & " in the region with code " & region_code & " with number of arable acres " & acres & " and total farms " & farms & " is " & subsidy)

                WriteLine(1)
                WriteLine(1, region_code, product_name, acres, farms, subsidy)


            End If

        Loop Until region_code = 0

        FileClose(1)

        FileOpen(1, "C:\temp\RESULTS.txt", OpenMode.Input)


        Dim sum_subsidy As Integer
        Dim sum_farms As Integer

        Dim sum_subsidy_region() As Integer = New Integer(12) {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}

        sum_subsidy = 0
        sum_farms = 0

        Dim word1, word2, word3, word4, word5 As String


        Do While Not EOF(1) 'Do
            line = LineInput(1)
            Input(1, word1)
            Input(1, word2)
            Input(1, word3)
            Input(1, word4)
            Input(1, word5)
            MsgBox(word1 & word2 & word3 & word4 & word5)
            If word1 <> Nothing And word2 <> Nothing And word3 <> Nothing And word4 <> Nothing And word5 <> Nothing Then
                If word2 = "WHEAT" Then
                    sum_subsidy = sum_subsidy + Integer.Parse(word5)
                    sum_farms = sum_farms + Integer.Parse(word4)
                End If

                sum_subsidy_region(Integer.Parse(word1) - 1) = sum_subsidy_region(Integer.Parse(word1) - 1) + Integer.Parse(word5)

            End If


        Loop

        FileClose(1)

        MsgBox("The total subsidy for the WHEAT product is " & sum_subsidy & " with " & sum_farms & " farms that will receive it")

        Dim max_subsidy = sum_subsidy_region.Max()
        Dim max_region As Integer

        For i = 0 To UBound(sum_subsidy_region)
            If max_subsidy = sum_subsidy_region(i) Then
                max_region = i + 1
            End If
        Next i

        MsgBox("The region with code " & max_region & " has the largest total subsidy, which was " & max_subsidy)


    End Sub