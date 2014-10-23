@ECHO OFF
SET ConfigurationName=%~1
SET SolutionDir=%~2
SET ProjectDir=%~3
SET CodeGenVer=1.0.0.48
@ECHO ON
"%SolutionDir%CodeGenerator-%CodeGenVer%\CodeGenerator.exe" "%ProjectDir%Code Templates\CompoundAttribute.template" "%ProjectDir%Code Templates\CompoundAttribute.replace" "%ProjectDir%Generated Code\$[TypeName]$Compound.cs" -overwrite
"%SolutionDir%CodeGenerator-%CodeGenVer%\CodeGenerator.exe" "%ProjectDir%Code Templates\RangeValueAttribute.template" "%ProjectDir%Code Templates\RangeValueAttribute.replace" "%ProjectDir%Generated Code\$[TypeName]$RangeValueAttribute.cs" -overwrite
@ECHO OFF
IF /I "%ConfigurationName%" == "Release" (
   @ECHO ON
   "%SolutionDir%AssemblyVersionIncrement-1.0.0.3\AssemblyVersionIncrement.exe" Build "%ProjectDir%Properties\AssemblyInfo.cs"
)