@ECHO OFF
SET ConfigurationName=%~1
SET SolutionDir=%~2
SET ProjectDir=%~3
SET CodeGenVer=1.0.0.48
SET AviVer=1.0.6.0
@ECHO ON
"%SolutionDir%CodeGenerator-%CodeGenVer%\CodeGenerator.exe" "%ProjectDir%Code Templates\CompoundAttribute.template" "%ProjectDir%Code Templates\CompoundAttribute.replace" "%ProjectDir%Generated Code\$[TypeName]$Compound.cs" -overwrite
"%SolutionDir%CodeGenerator-%CodeGenVer%\CodeGenerator.exe" "%ProjectDir%Code Templates\RangeValueAttribute.template" "%ProjectDir%Code Templates\RangeValueAttribute.replace" "%ProjectDir%Generated Code\$[TypeName]$RangeValueAttribute.cs" -overwrite
@ECHO OFF
SET VersionPart=Build
IF /I "%ConfigurationName%" == "Release" (
   SET VersionPart=Maintenance
)
@ECHO ON
"%SolutionDir%AssemblyVersionIncrement-%AviVer%\AssemblyVersionIncrement.exe" %VersionPart% "%ProjectDir%Properties\AssemblyInfo.cs"