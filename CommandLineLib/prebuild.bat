@ECHO OFF
SET ConfigurationName=%~1
SET SolutionDir=%~2
SET ProjectDir=%~3
@ECHO ON
"%SolutionDir%CodeGenerator-1.0.0.45\CodeGenerator.exe" "%ProjectDir%Code Templates\ValueAttribute.template" "%ProjectDir%Code Templates\ValueAttribute.replace" "%ProjectDir%Generated Code\$<TypeName>$Attribute.cs" -overwrite -silent
@ECHO OFF
IF /I "%ConfigurationName%" == "Release" (
   @ECHO ON
   "%SolutionDir%AssemblyVersionIncrement-1.0.0.3\AssemblyVersionIncrement.exe" Build "%ProjectDir%Properties\AssemblyInfo.cs"
)