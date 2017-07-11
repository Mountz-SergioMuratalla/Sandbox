<?xml version='1.0' encoding='UTF-8'?>
<Project Type="Project" LVVersion="17008000">
	<Property Name="CCSymbols" Type="Str"></Property>
	<Property Name="NI.LV.All.SourceOnly" Type="Bool">false</Property>
	<Property Name="NI.Project.Description" Type="Str"></Property>
	<Item Name="My Computer" Type="My Computer">
		<Property Name="server.app.propertiesEnabled" Type="Bool">true</Property>
		<Property Name="server.control.propertiesEnabled" Type="Bool">true</Property>
		<Property Name="server.tcp.enabled" Type="Bool">false</Property>
		<Property Name="server.tcp.port" Type="Int">0</Property>
		<Property Name="server.tcp.serviceName" Type="Str">My Computer/VI Server</Property>
		<Property Name="server.tcp.serviceName.default" Type="Str">My Computer/VI Server</Property>
		<Property Name="server.vi.callsEnabled" Type="Bool">true</Property>
		<Property Name="server.vi.propertiesEnabled" Type="Bool">true</Property>
		<Property Name="specify.custom.address" Type="Bool">false</Property>
		<Item Name="deltamovectrl.dll" Type="Document" URL="../../deltamovectrl/deltamovectrl/bin/Debug/netstandard1.4/deltamovectrl.dll"/>
		<Item Name="moveM1motor.vi" Type="VI" URL="../moveM1motor.vi"/>
		<Item Name="nodlltests.vi" Type="VI" URL="../nodlltests.vi"/>
		<Item Name="Dependencies" Type="Dependencies">
			<Item Name="DELETE.dll" Type="Document" URL="../DELETE.dll"/>
			<Item Name="DeltaMotorLibrary.dll" Type="Document" URL="../../../Libraries/Delta/DeltaMotorLibrary/DeltaMotorLibrary/bin/Debug/netstandard1.4/DeltaMotorLibrary.dll"/>
		</Item>
		<Item Name="Build Specifications" Type="Build">
			<Item Name="m1test" Type="EXE">
				<Property Name="App_copyErrors" Type="Bool">true</Property>
				<Property Name="App_INI_aliasGUID" Type="Str">{59FE4AF7-B562-44F5-989B-6D2F8FC5637C}</Property>
				<Property Name="App_INI_GUID" Type="Str">{F1DE0469-B731-445B-8EA9-3503D0C1A2DB}</Property>
				<Property Name="App_serverConfig.httpPort" Type="Int">8002</Property>
				<Property Name="Bld_autoIncrement" Type="Bool">true</Property>
				<Property Name="Bld_buildCacheID" Type="Str">{2A480408-75EB-4D0B-8A4A-91CA278CBC52}</Property>
				<Property Name="Bld_buildSpecName" Type="Str">m1test</Property>
				<Property Name="Bld_excludeInlineSubVIs" Type="Bool">true</Property>
				<Property Name="Bld_excludeLibraryItems" Type="Bool">true</Property>
				<Property Name="Bld_excludePolymorphicVIs" Type="Bool">true</Property>
				<Property Name="Bld_localDestDir" Type="Path">../builds/moveM1motor</Property>
				<Property Name="Bld_localDestDirType" Type="Str">relativeToProject</Property>
				<Property Name="Bld_modifyLibraryFile" Type="Bool">true</Property>
				<Property Name="Bld_previewCacheID" Type="Str">{E8833EF7-56E0-4D57-99ED-09F78113BD57}</Property>
				<Property Name="Bld_version.build" Type="Int">3</Property>
				<Property Name="Bld_version.major" Type="Int">1</Property>
				<Property Name="Destination[0].destName" Type="Str">m1test.exe</Property>
				<Property Name="Destination[0].path" Type="Path">../builds/moveM1motor/m1test.exe</Property>
				<Property Name="Destination[0].path.type" Type="Str">relativeToProject</Property>
				<Property Name="Destination[0].preserveHierarchy" Type="Bool">true</Property>
				<Property Name="Destination[0].type" Type="Str">App</Property>
				<Property Name="Destination[1].destName" Type="Str">Support Directory</Property>
				<Property Name="Destination[1].path" Type="Path">../builds/moveM1motor/data</Property>
				<Property Name="Destination[1].path.type" Type="Str">relativeToProject</Property>
				<Property Name="DestinationCount" Type="Int">2</Property>
				<Property Name="Source[0].itemID" Type="Str">{A55315B5-C9C3-4E56-A60E-C0D214E3072D}</Property>
				<Property Name="Source[0].type" Type="Str">Container</Property>
				<Property Name="Source[1].destinationIndex" Type="Int">0</Property>
				<Property Name="Source[1].itemID" Type="Ref">/My Computer/moveM1motor.vi</Property>
				<Property Name="Source[1].sourceInclusion" Type="Str">TopLevel</Property>
				<Property Name="Source[1].type" Type="Str">VI</Property>
				<Property Name="Source[2].destinationIndex" Type="Int">0</Property>
				<Property Name="Source[2].itemID" Type="Ref">/My Computer/deltamovectrl.dll</Property>
				<Property Name="Source[2].sourceInclusion" Type="Str">Include</Property>
				<Property Name="SourceCount" Type="Int">3</Property>
				<Property Name="TgtF_companyName" Type="Str">Mountz Inc</Property>
				<Property Name="TgtF_fileDescription" Type="Str">m1test</Property>
				<Property Name="TgtF_internalName" Type="Str">m1test</Property>
				<Property Name="TgtF_legalCopyright" Type="Str">Copyright © 2017 Mountz Inc</Property>
				<Property Name="TgtF_productName" Type="Str">m1test</Property>
				<Property Name="TgtF_targetfileGUID" Type="Str">{89A74C03-67AE-4466-A348-91E061384F36}</Property>
				<Property Name="TgtF_targetfileName" Type="Str">m1test.exe</Property>
				<Property Name="TgtF_versionIndependent" Type="Bool">true</Property>
			</Item>
		</Item>
	</Item>
</Project>
