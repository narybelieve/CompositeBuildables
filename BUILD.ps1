while($true) {
	cls
	& 'C:\Program Files (x86)\Microsoft Visual Studio\2022\BuildTools\MSBuild\Current\Bin\amd64\MSBuild.exe'
	Read-Host -Prompt "Press Enter to restart"
	# IF THIS COMPLAINS ABOUT NUGET, RUN "dotnet restore" not nuget
}