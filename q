[1mdiff --git a/Calculator/Calculator.cs b/Calculator/Calculator.cs[m
[1mindex 05e5e4a..c0fe494 100644[m
[1m--- a/Calculator/Calculator.cs[m
[1m+++ b/Calculator/Calculator.cs[m
[36m@@ -38,12 +38,10 @@[m [mnamespace CalculatorAlgorithm[m
                 for(int i = 0; i < _varCount; i++) if (_variables[i][0] == varName) _variables[i][1] = value; [m
             }[m
            [m
[31m-            //Функція що клеїть токен зі значень з буфера та його очищує[m
             void EmptyBuffer()[m
             {[m
                 if (buffer != "")[m
                 {[m
[31m-                    // Проверяем, с чего начинается накопленное слово[m
                     if (char.IsLetter(buffer[0]))[m
                     {[m
                         if (isVariable(buffer)) tokens.Add(FindValue(buffer));[m
