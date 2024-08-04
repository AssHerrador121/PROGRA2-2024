Imports System.IO

Module Module1

    Sub Main()
        Dim opcion As Char = ""
        Dim opcion2 As ConsoleKeyInfo
        Dim nombre, imc2 As String
        Dim peso, altura, imc As Double
        Do
            Try
                Console.Clear()
                Console.WriteLine("MENU DE OPCIONES")
                Console.WriteLine("1. CALCULAR IMC")
                Console.WriteLine("2. VER HISTORIAL")
                Console.WriteLine("3. BORRAR HISTORIAL")
                Console.WriteLine("4. SALIR")
                Console.WriteLine("POR FAVOR SELECCIONE UNA OPCION")
                opcion2 = Console.ReadKey()
                opcion = opcion2.KeyChar
                Console.Clear()
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
            Select Case opcion
                Case "1"
                    Try
                        Console.Clear()
                        Console.WriteLine("INGRESE SU NOMBRE:")
                        nombre = Console.ReadLine()
                        Console.WriteLine("INGRESE SU PESO EN KG:")
                        peso = Double.Parse(Console.ReadLine())
                        Console.WriteLine("INGRESE SU ALTURA EN M:")
                        altura = Double.Parse(Console.ReadLine())
                        Console.Clear()
                        imc = peso / (altura * altura)
                        Dim resultado As String = If(imc <= 18.5, "BAJO DE PESO",
                            If(imc <= 24.9, "PESO NORMAL",
                            If(imc <= 29.9, "SOBREPESO",
                            If(imc <= 34.9, "OBESIDAD GRADO I",
                            If(imc <= 39.9, "OBESIDAD GRADO II", "OBSESIDAD GRADO III (OBESIDAD MORBIDA)")))))
                        imc2 = imc.ToString("F4")
                        Console.WriteLine("SU IMC ES:" & imc2 & "" & resultado)
                        Dim historial As StreamWriter
                        historial = File.AppendText("historial_imc.txt")
                        historial.WriteLine(nombre & ", " &peso &”, "& altura & ", " &imc2 &", " & resultado)
                        historial.Close ()
                        Console.WriteLine("Resultado guardado en el historial.")
                    Catch ex As DivideByZeroException
                        Console.WriteLine(”La altura no puede ser cero.")
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                    Console.ReadKey()
                Case "2"
                    Console.Clear()
                    Try
                        Dim historial As StreamReader
                        historial = File.OpenText("historial_imc.txt")
                        Console.WriteLine("Nombre, Peso, Altura, IMC, Resultado”)
                        Do Until historial.EndOfStream
                            Console.WriteLine(historial.ReadLine())
                        Loop
                        historial.Close()
                    Catch ex As FileNotFoundException
                        Console.WriteLine("El archivo de historial no existe.”)
                    End Try
                        Console.WriteLine("")
                    Console.WriteLine(”Presione cualquier tecla”)
                    Console.ReadKey()
                    Case "3"
                      Dim historial As String = "historial_imc.txt”
                      File.Delete(historial)
                    Console.WriteLine("Borrar historial")
                    Console.ReadKey()
                Case "4"
                    Console.Clear()
                    Console.WriteLine("Hasta pronto.")
                    Exit Do
                    Console.ReadKey()
                Case Else
                    Console.WriteLine("Opción no válida.”)
            End Select
Loop 




    End Sub

End Module
