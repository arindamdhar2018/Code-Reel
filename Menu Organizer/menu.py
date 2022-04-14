import nuke
import nukescripts
import Core_File


menu = nuke.menu("Nuke")
org = menu.addMenu("Menu Organizer")
org.addCommand("Node Menu Organizer","Core_File.start()")
