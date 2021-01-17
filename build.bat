@ECHO off
rem This script assumes that csc.exe is in the Path.
cd src
csc Program.cs HttpCodeDisplay.cs /r:System.Net.Http.dll
move Program.exe ..
cd ..
ren Program.exe ezwebdl.exe