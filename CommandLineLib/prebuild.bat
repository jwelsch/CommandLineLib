@ECHO OFF
SET ConfigurationName=%~1
SET SolutionDir=%~2
SET ProjectDir=%~3
SET CodeGenVer=1.0.0.46
@ECHO ON
"%SolutionDir%CodeGenerator-%CodeGenVer%\CodeGenerator.exe" "%ProjectDir%Code Templates\ValueAttribute.template" "%ProjectDir%Code Templates\ValueAttribute.replace" "%ProjectDir%Generated Code\$<TypeName>$Attribute.cs" -overwrite
"%SolutionDir%CodeGenerator-%CodeGenVer%\CodeGenerator.exe" "%ProjectDir%Code Templates\CompoundAttribute.template" "%ProjectDir%Code Templates\CompoundAttribute.replace" "%ProjectDir%Generated Code\$<TypeName>$CompoundAttribute.cs" -overwrite
@ECHO OFF
IF /I "%ConfigurationName%" == "Release" (
   @ECHO ON
   "%SolutionDir%AssemblyVersionIncrement-1.0.0.3\AssemblyVersionIncrement.exe" Build "%ProjectDir%Properties\AssemblyInfo.cs"
)