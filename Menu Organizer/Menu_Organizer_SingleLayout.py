try:
    from PySide import QtCore as QtCore
    from PySide import QtGui as QtGui
    from PySide import QtGui as QtGuiWidgets

except ImportError:
    from PySide2 import QtCore as QtCore
    from PySide2 import QtGui as QtGui
    from PySide2 import QtWidgets as QtGuiWidgets

import nukefunc
import os.path

class mainMenu(QtGuiWidgets.QWidget):
    def __init__(self,ItemList):
        super(mainMenu, self).__init__()
        self.setEnabled(True)
        self.resize(317, 416)
        sizePolicy = QtGuiWidgets.QSizePolicy(QtGuiWidgets.QSizePolicy.Preferred, QtGuiWidgets.QSizePolicy.Preferred)
        sizePolicy.setHorizontalStretch(0)
        sizePolicy.setVerticalStretch(0)
        sizePolicy.setHeightForWidth(self.sizePolicy().hasHeightForWidth())
        self.setSizePolicy(sizePolicy)
        self.setMinimumSize(QtCore.QSize(317, 416))
        self.setMaximumSize(QtCore.QSize(475, 632))
        self.setFocusPolicy(QtCore.Qt.NoFocus)
        self.setAutoFillBackground(False)


        mainMenu_Label = labelMenu()
        self.nodeMenuItems = treeWidget(ItemList)
        menuItems_verticalLayout = QtGuiWidgets.QVBoxLayout()
        menuItems_verticalLayout.setSpacing(4)
        menuItems_verticalLayout.setSpacing(0)
        menuItems_verticalLayout.addWidget(mainMenu_Label)
        menuItems_verticalLayout.addWidget(self.nodeMenuItems)
        menuItems_verticalLayout.setStretch(0, 20)
        menuItems_verticalLayout.setStretch(1, 80)
        frame = frameBackdrop()
        combo_VerticalLayout = QtGuiWidgets.QVBoxLayout()
        combo_VerticalLayout.setSpacing(4)
        combo_VerticalLayout.addLayout(menuItems_verticalLayout)
        combo_VerticalLayout.addWidget(frame)
        combo_VerticalLayout.setStretch(0, 80)
        combo_VerticalLayout.setStretch(1, 20)
        self.setLayout(combo_VerticalLayout)

class labelMenu(QtGuiWidgets.QLabel):
    def __init__(self):
        super(labelMenu, self).__init__()
        self.setMaximumSize(QtCore.QSize(16777215, 16777215))
        font = QtGui.QFont()
        font.setPointSize(12)
        font.setWeight(75)
        font.setBold(False)
        self.setFont(font)
        self.setMouseTracking(False)
        self.setText("Menu Items")
        self.setLayoutDirection(QtCore.Qt.LeftToRight)
        self.setAutoFillBackground(False)
        self.setStyleSheet("background-color: rgb(80, 80, 80);\n" "color: rgb(240, 240, 240);")
        self.setAlignment(QtCore.Qt.AlignCenter)

class treeWidget(QtGuiWidgets.QTreeWidget):
    def __init__(self,Item_List):
        super(treeWidget, self).__init__()
        self.setSizeIncrement(QtCore.QSize(6, 0))
        palette = QtGui.QPalette()
        brush = QtGui.QBrush(QtGui.QColor(182, 199, 168))
        brush.setStyle(QtCore.Qt.SolidPattern)
        palette.setBrush(QtGui.QPalette.Active, QtGui.QPalette.Button, brush)
        brush = QtGui.QBrush(QtGui.QColor(182, 199, 168))
        brush.setStyle(QtCore.Qt.SolidPattern)
        palette.setBrush(QtGui.QPalette.Active, QtGui.QPalette.Base, brush)
        brush = QtGui.QBrush(QtGui.QColor(182, 199, 168))
        brush.setStyle(QtCore.Qt.SolidPattern)
        palette.setBrush(QtGui.QPalette.Active, QtGui.QPalette.Window, brush)
        brush = QtGui.QBrush(QtGui.QColor(141, 155, 148))
        brush.setStyle(QtCore.Qt.SolidPattern)
        palette.setBrush(QtGui.QPalette.Active, QtGui.QPalette.Highlight, brush)
        brush = QtGui.QBrush(QtGui.QColor(0, 0, 0))
        brush.setStyle(QtCore.Qt.SolidPattern)
        palette.setBrush(QtGui.QPalette.Active, QtGui.QPalette.HighlightedText, brush)
        brush = QtGui.QBrush(QtGui.QColor(70, 70, 70))
        brush.setStyle(QtCore.Qt.SolidPattern)
        palette.setBrush(QtGui.QPalette.Active, QtGui.QPalette.AlternateBase, brush)
        brush = QtGui.QBrush(QtGui.QColor(182, 199, 168))
        brush.setStyle(QtCore.Qt.SolidPattern)
        palette.setBrush(QtGui.QPalette.Inactive, QtGui.QPalette.Button, brush)
        brush = QtGui.QBrush(QtGui.QColor(182, 199, 168))
        brush.setStyle(QtCore.Qt.SolidPattern)
        palette.setBrush(QtGui.QPalette.Inactive, QtGui.QPalette.Base, brush)
        brush = QtGui.QBrush(QtGui.QColor(182, 199, 168))
        brush.setStyle(QtCore.Qt.SolidPattern)
        palette.setBrush(QtGui.QPalette.Inactive, QtGui.QPalette.Window, brush)
        brush = QtGui.QBrush(QtGui.QColor(141, 155, 148))
        brush.setStyle(QtCore.Qt.SolidPattern)
        palette.setBrush(QtGui.QPalette.Inactive, QtGui.QPalette.Highlight, brush)
        brush = QtGui.QBrush(QtGui.QColor(0, 0, 0))
        brush.setStyle(QtCore.Qt.SolidPattern)
        palette.setBrush(QtGui.QPalette.Inactive, QtGui.QPalette.HighlightedText, brush)
        brush = QtGui.QBrush(QtGui.QColor(70, 70, 70))
        brush.setStyle(QtCore.Qt.SolidPattern)
        palette.setBrush(QtGui.QPalette.Inactive, QtGui.QPalette.AlternateBase, brush)
        self.setPalette(palette)
        font = QtGui.QFont()
        font.setPointSize(10)
        font.setWeight(50)
        font.setItalic(False)
        font.setStrikeOut(False)
        font.setBold(False)
        self.setFont(font)
        self.setMouseTracking(False)
        self.setFocusPolicy(QtCore.Qt.WheelFocus)
        self.setAcceptDrops(False)
        self.setAutoFillBackground(False)
        self.setStyleSheet("background-color: rgb(60, 60, 60);\n""color: rgb(255, 255, 255);")
        self.setFrameShape(QtGuiWidgets.QFrame.StyledPanel)
        self.setFrameShadow(QtGuiWidgets.QFrame.Raised)
        self.setLineWidth(10)
        self.setMidLineWidth(10)
        self.setEditTriggers(QtGuiWidgets.QAbstractItemView.EditKeyPressed | QtGuiWidgets.QAbstractItemView.SelectedClicked)
        self.setDragEnabled(True)
        self.setDragDropOverwriteMode(True)
        self.setDragDropMode(QtGuiWidgets.QAbstractItemView.InternalMove)
        self.setAlternatingRowColors(True)
        self.setSelectionMode(QtGuiWidgets.QAbstractItemView.ExtendedSelection)
        self.setSelectionBehavior(QtGuiWidgets.QAbstractItemView.SelectRows)
        self.setAutoExpandDelay(-1)
        self.setRootIsDecorated(True)
        self.setUniformRowHeights(False)
        self.setItemsExpandable(True)
        self.setAnimated(True)
        self.setAllColumnsShowFocus(True)
        self.setWordWrap(False)
        self.setHeaderHidden(True)
        self.setExpandsOnDoubleClick(True)
        self.setObjectName("nodeMenuItems")
        self.header().setVisible(False)
        self.header().setCascadingSectionResizes(False)
        self.header().setHighlightSections(False)
        self.header().setSortIndicatorShown(False)
        self.loadMenu(Item_List)
        self.mimeString = ""
        self.itemClicked.connect(self.childSelect)
        self.itemSelectionChanged.connect(self.selectedMimeDataUpdater)

    def loadMenu(self,search_list):

        nodeMenuList = nukefunc.gatherMenuItems(search_list)
        for menuKey, menuValue in nodeMenuList.items():
            menuItems = QtGuiWidgets.QTreeWidgetItem(self)
            menuItems.setText(0,menuKey)
            menuItemsfont = QtGui.QFont()
            menuItemsfont.setPointSize(11)
            menuItemsfont.setBold(True)
            menuItems.setFont(0,menuItemsfont)
            for subKey, subValue in menuValue.items():
                subMenuItems = QtGuiWidgets.QTreeWidgetItem(menuItems)
                subMenuItems.setText(0,subKey)
                subMenuItemsfont = QtGui.QFont()
                subMenuItemsfont.setPointSize(11)
                subMenuItemsfont.setBold(False)
                subMenuItems.setFont(0, subMenuItemsfont)
                for subSubValue in subValue:
                    subSubMenuItems = QtGuiWidgets.QTreeWidgetItem(subMenuItems)
                    subSubMenuItems.setText(0, subSubValue)
                    subSubMenuItemsfont = QtGui.QFont()
                    subSubMenuItemsfont.setPointSize(10)
                    subSubMenuItemsfont.setBold(False)
                    subSubMenuItems.setFont(0, subSubMenuItemsfont)

    def childSelect(self):
        for item in self.selectedItems():
            for index in range(0,item.childCount()):
                item.child(index).setSelected(True)
                for index1 in range(item.child(index).childCount()):
                    item.child(index).child(index1).setSelected(True)

    def dragEnterEvent(self, e):
        #print "drg"
        #mycursor = QtGui.QCursor((QtCore.Qt.OpenHandCursor))
        #self.setCursor(mycursor)
        if self.selectedItems() is not None or len(self.selectedItems()) != 0:
            print "DragEnter", self.selectedItems()
            e.accept()
        else:
            print "Dragenter not accpeted"
            e.decline()

    def dropEvent(self, e):
        #print "Drop"
        print e.mimeData().formats()
        # if e.mimeData().hasText():
        #     print "DropEvent"
        #     print e.mimeData().data("text/plain")
        # else:
        #     print "boo"
        # nuke.dropData("text/plain", e.mimeData.data("text/plain") )
        # mime_dict = {}
        # for format in e.mimeData().formats():
        #     mime_dict[format] = e.mimeData().data(format)
        # self.mime_dict = mime_dict
        # print e.mimeData().formats()

    def mouseMoveEvent(self, e):
        #print "MME"
        mimeData = QtCore.QMimeData()
        mimeData.setData("text/plain", self.mimeString)
        # for format, value in self.mime_dict.iteritems():
        #     if format not in [u'text/uri-list']:
        #         mimeData.setData(format, value)
        drag = QtGui.QDrag(self)
        drag.setMimeData(mimeData)

        handCursor = QtGui.QPixmap("grabhand.jpg")
        #self.render(handCursor)
        drag.setPixmap(handCursor)
        drag.setDragCursor(handCursor,QtCore.Qt.MoveAction)
        #pix = QtGui.QPixmap(self.size())
        #self.pixmap = pix.grabWidget(self, event.pos().x(), event.pos().y(), 100, 25)
        #self.pixmap = self.grab(QtCore.QRect(drag.hotSpot(), QtCore.QSize(11, 16)))
        #self.render(self.pixmap)
        #drag.setPixmap(self.pixmap)
        drag.setHotSpot(e.pos())
        dropAction = drag.start(QtCore.Qt.MoveAction)

    def selectedMimeDataUpdater(self):
        print "Selected - MimeString updated"
        selectedItems = self.selectedItems()  # returns list
        mimeString = self.itemsToMimeString(selectedItems)
        self.mimeString = mimeString

    def itemsToMimeString(self, items):
        # convertselection to string
        if len(items) != 0 or items != None:
            mimeString = ""
            itemstringlist = []

            for item in items:
                menu = item.text(0).encode("utf-8")
                #itemstring = ";;".join(menu)
                itemstringlist.append(menu)

            mimeString = "}---{".join(itemstringlist)
            print "Mime String generated ",mimeString
            return mimeString


    def mousePressEvent(self, event):
        if event.buttons() == QtCore.Qt.LeftButton:
            QtGuiWidgets.QTreeWidget.mousePressEvent(self, event)
            #pix = QtGui.QPixmap(self.size())
            #self.pixmap = pix.grabWidget(self, event.pos().x(), event.pos().y(), 100, 25)

            return
        elif event.buttons() == QtCore.Qt.RightButton:
            self.createContextMenu()

    def createContextMenu(self):
        self.setContextMenuPolicy(QtCore.Qt.CustomContextMenu)
        self.customContextMenuRequested.connect(self.showContextMenu)

        self.contextMenu = QtGuiWidgets.QMenu(self)
        font = QtGui.QFont()
        font.setPointSize(10)
        font.setWeight(50)
        font.setItalic(False)
        font.setStrikeOut(False)
        font.setBold(False)
        self.contextMenu.setFont(font)
        self.set_contextStyleSheet()

        self.actionA = self.contextMenu.addAction(u'Remove from Menu')
        self.actionB = self.contextMenu.addAction(u'Restore in Menu')
        self.actionC = self.contextMenu.addAction(u'Move to Survival Kit')
        self.contextMenu.addSeparator()
        self.actionD = self.contextMenu.addAction(u'Open Documentation')


        self.actionA.triggered.connect(self.removeactionHandler)
        self.actionB.triggered.connect(self.addactionHandler)

    def set_contextStyleSheet(self):
        usr = os.path.expanduser("~")
        path = os.path.join(usr,'.nuke\Menu_Organizer','style.txt')
        normpath = os.path.normpath(path)
        sheet = open(normpath).read()
        self.contextMenu.setStyleSheet(sheet)

    def showContextMenu(self, pos):
        self.contextMenu.move(QtGui.QCursor().pos())
        if self.currentItem().isSelected():
            self.contextMenu.show()

    def removeactionHandler(self):
        for item in self.selectedItems():
            f = item.font(0)
            removefont = QtGui.QFont()
            removefont.setPointSize(f.pointSize())
            removefont.setWeight(50)
            removefont.setItalic(True)
            removefont.setStrikeOut(True)
            removefont.setBold(f.bold())
            item.setFont(0,removefont)

    def addactionHandler(self):
        for item in self.selectedItems():
            f = item.font(0)
            addfont = QtGui.QFont()
            addfont.setPointSize(f.pointSize())
            addfont.setWeight(50)
            addfont.setItalic(False)
            addfont.setStrikeOut(False)
            addfont.setBold(f.bold())
            item.setFont(0,addfont)

class frameBackdrop(QtGuiWidgets.QFrame):
    def __init__(self):
        super(frameBackdrop, self).__init__()
        sizePolicy = QtGuiWidgets.QSizePolicy(QtGuiWidgets.QSizePolicy.Expanding, QtGuiWidgets.QSizePolicy.Expanding)
        sizePolicy.setHorizontalStretch(0)
        sizePolicy.setVerticalStretch(0)
        sizePolicy.setHeightForWidth(self.sizePolicy().hasHeightForWidth())
        self.setSizePolicy(sizePolicy)
        #self.setStyleSheet("background-color: rgb(90, 90, 90);")
        #self.setFrameShape(QtGuiWidgets.QFrame.StyledPanel)
        #self.setFrameShadow(QtGuiWidgets.QFrame.Raised)
        self.set_contextStyleSheet()


    def set_contextStyleSheet(self):
        usr = os.path.expanduser("~")
        path = os.path.join(usr, '.nuke\Menu_Organizer', 'style.txt')
        normpath = os.path.normpath(path)
        sheet = open(normpath).read()
        self.setStyleSheet(sheet)

        save = saveButton()
        reset = resetButton()
        frameHorizontalLayout = QtGuiWidgets.QHBoxLayout()
        saveReset_horizontalLayout = QtGuiWidgets.QHBoxLayout()
        saveReset_horizontalLayout.addWidget(save)
        saveReset_horizontalLayout.addWidget(reset)
        frameHorizontalLayout.addLayout(saveReset_horizontalLayout)
        self.setLayout(frameHorizontalLayout)

class saveButton(QtGuiWidgets.QPushButton):
    def __init__(self):
        super(saveButton, self).__init__()
        sizePolicy = QtGuiWidgets.QSizePolicy(QtGuiWidgets.QSizePolicy.Fixed, QtGuiWidgets.QSizePolicy.Fixed)
        sizePolicy.setHorizontalStretch(0)
        sizePolicy.setVerticalStretch(0)
        sizePolicy.setHeightForWidth(self.sizePolicy().hasHeightForWidth())
        self.setSizePolicy(sizePolicy)
        self.setText("Save")
        self.setMinimumSize(QtCore.QSize(30, 30))
        self.setStyleSheet("background-color: rgb(100, 100, 100);")

        self.set_contextStyleSheet()

    def set_contextStyleSheet(self):
        usr = os.path.expanduser("~")
        path = os.path.join(usr, '.nuke\Menu_Organizer', 'style.txt')
        normpath = os.path.normpath(path)
        sheet = open(normpath).read()
        self.setStyleSheet(sheet)

class resetButton(QtGuiWidgets.QPushButton):
    def __init__(self):
        super(resetButton, self).__init__()
        sizePolicy = QtGuiWidgets.QSizePolicy(QtGuiWidgets.QSizePolicy.Fixed, QtGuiWidgets.QSizePolicy.Fixed)
        sizePolicy.setHorizontalStretch(0)
        sizePolicy.setVerticalStretch(0)
        sizePolicy.setHeightForWidth(self.sizePolicy().hasHeightForWidth())
        self.setSizePolicy(sizePolicy)
        self.setText("Reset")
        self.setMinimumSize(QtCore.QSize(30, 30))
        self.setStyleSheet("background-color: rgb(100, 100, 100);")

        self.set_contextStyleSheet()

    def set_contextStyleSheet(self):
        usr = os.path.expanduser("~")
        path = os.path.join(usr, '.nuke\Menu_Organizer', 'style.txt')
        normpath = os.path.normpath(path)
        sheet = open(normpath).read()
        self.setStyleSheet(sheet)



