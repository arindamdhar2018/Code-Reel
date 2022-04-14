try:
    from PySide import QtCore as QtCore
    from PySide import QtGui as QtGui
    from PySide import QtGui as QtGuiWidgets

except:
    from PySide2 import QtCore as QtCore
    from PySide2 import QtGui as QtGui
    from PySide2 import QtWidgets as QtGuiWidgets

from Menu_Organizer_SingleLayout import mainMenu


# Pass the node name for which you want to gather nodeinfo
Item_List = ['3D','Deep']



class Panel(mainMenu):
    def __init__(self,Item_List ):
        mainMenu.__init__(self, Item_List)
        #super(Panel, self).__init__(Item_List)
        self.setWindowTitle("Node Menu Organizer")

def start():
    start.panel = Panel(Item_List)
    start.panel.show()
