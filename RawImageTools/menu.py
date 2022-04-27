import nuke
import SelectByMetadata
import SelectByName

menu = nuke.menu("Nodes")
byMetaData = menu.addMenu("Raw ImageTool")
byMetaData.addCommand("Raw ImageTool/Select By Metadata","SelectByMetadata.main()")
byMetaData.addCommand("Raw ImageTool/Select By Name","SelectByName.main()")
