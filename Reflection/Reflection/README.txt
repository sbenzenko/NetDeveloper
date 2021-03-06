.Net DLL/EXE Object Inspector

1. Put dll or exe file(s) to inspect into /files folder.
2. Put any dependent dlls into /libs folder.
3. Run Reflection.exe
4. Go to /logs folder, open the most recent txt file.

------------------------------------------------------------

Инспектор объектов .Net в DLL/EXE

1. Разместите dll или exe файл(ы) для инспекции в папке /files.
2. Разместите любые библиотеки dll, от которых зависит инспектируемый файл, в папке /libs.
3. Запустите Reflection.exe
4. В папке /logs откройте наиболее свежий файл txt.

-------------------------------------------------------------

Output file format / Формат файла результатов :

================================================================================
Reading file: files\<FileName>
================================================================================
Assembly: <AssemblyName>, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null

    Type: <AssemblyName>.<TypeName>
      Method      : Int32 Method()
      Constructor : Void .ctor()
      Property    : Int32 Prop
      Field       : Boolean fieldName
================================================================================