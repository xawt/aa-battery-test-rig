<?xml version='1.0' encoding='UTF-8'?>
<Project Type="Project" LVVersion="25008000">
	<Property Name="NI.LV.All.SaveVersion" Type="Str">25.0</Property>
	<Property Name="NI.LV.All.SourceOnly" Type="Bool">true</Property>
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
		<Item Name="subvi" Type="Folder" URL="../../src/subvi">
			<Property Name="NI.DISK" Type="Bool">true</Property>
		</Item>
		<Item Name="battery-prompt.lvlibp" Type="LVLibp" URL="../../../../artifacts/battery-prompt/battery-prompt.lvlibp">
			<Item Name="Build Prompt.vi" Type="VI" URL="../../../../artifacts/battery-prompt/battery-prompt.lvlibp/Build Prompt.vi"/>
			<Item Name="Check if File or Folder Exists.vi" Type="VI" URL="../../../../artifacts/battery-prompt/battery-prompt.lvlibp/1abvi3w/vi.lib/Utility/libraryn.llb/Check if File or Folder Exists.vi"/>
			<Item Name="Clear Errors.vi" Type="VI" URL="../../../../artifacts/battery-prompt/battery-prompt.lvlibp/1abvi3w/vi.lib/Utility/error.llb/Clear Errors.vi"/>
			<Item Name="Error Cluster From Error Code.vi" Type="VI" URL="../../../../artifacts/battery-prompt/battery-prompt.lvlibp/1abvi3w/vi.lib/Utility/error.llb/Error Cluster From Error Code.vi"/>
			<Item Name="LabVIEWHTTPClient.lvlib" Type="Library" URL="../../../../artifacts/battery-prompt/battery-prompt.lvlibp/1abvi3w/vi.lib/httpClient/LabVIEWHTTPClient.lvlib"/>
			<Item Name="Load Env File.vi" Type="VI" URL="../../../../artifacts/battery-prompt/battery-prompt.lvlibp/Load Env File.vi"/>
			<Item Name="Load Image as Byte64.vi" Type="VI" URL="../../../../artifacts/battery-prompt/battery-prompt.lvlibp/Load Image as Byte64.vi"/>
			<Item Name="NI_FileType.lvlib" Type="Library" URL="../../../../artifacts/battery-prompt/battery-prompt.lvlibp/1abvi3w/vi.lib/Utility/lvfile.llb/NI_FileType.lvlib"/>
			<Item Name="NI_PackedLibraryUtility.lvlib" Type="Library" URL="../../../../artifacts/battery-prompt/battery-prompt.lvlibp/1abvi3w/vi.lib/Utility/LVLibp/NI_PackedLibraryUtility.lvlib"/>
			<Item Name="Parse out Content.vi" Type="VI" URL="../../../../artifacts/battery-prompt/battery-prompt.lvlibp/Parse out Content.vi"/>
			<Item Name="Path To Command Line String.vi" Type="VI" URL="../../../../artifacts/battery-prompt/battery-prompt.lvlibp/1abvi3w/vi.lib/AdvancedString/Path To Command Line String.vi"/>
			<Item Name="Run Prompt with IMG.vi" Type="VI" URL="../../../../artifacts/battery-prompt/battery-prompt.lvlibp/Run Prompt with IMG.vi"/>
			<Item Name="Trim Whitespace One-Sided.vi" Type="VI" URL="../../../../artifacts/battery-prompt/battery-prompt.lvlibp/1abvi3w/vi.lib/Utility/error.llb/Trim Whitespace One-Sided.vi"/>
			<Item Name="Trim Whitespace.vi" Type="VI" URL="../../../../artifacts/battery-prompt/battery-prompt.lvlibp/1abvi3w/vi.lib/Utility/error.llb/Trim Whitespace.vi"/>
			<Item Name="whitespace.ctl" Type="VI" URL="../../../../artifacts/battery-prompt/battery-prompt.lvlibp/1abvi3w/vi.lib/Utility/error.llb/whitespace.ctl"/>
		</Item>
		<Item Name="battery-reader-dialog.vi" Type="VI" URL="../../src/battery-reader-dialog.vi"/>
		<Item Name="Dependencies" Type="Dependencies"/>
		<Item Name="Build Specifications" Type="Build"/>
	</Item>
</Project>
