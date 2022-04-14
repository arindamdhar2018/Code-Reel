import nuke 
import re 

from rawlmageTools.helpers import deselectAllNodes 


def selectByNodeName(searchString): 

	""" Iterate an selected nodes and searches their node name for matching criteria to the specified search string. 

	Args:
		searchString (str): String to use as search criteria 
	"""

	# Define list of nodes to search through

	nodes = nuke.selectedNodes() or nuke.allNodes()

	# Select Matching backdrops 
	deselectAllNodes() 
	for node in nodes: 
		if re.findall(searchString, node.name(), re.IGNORECASE): 
			node.knob('selected').setValue(True) 

def main(): 
	""" Launch a Nuke panel, then can selectByMetadata with using the user defined 	search string. 
	"""

	panel = nuke.Panel('Select by Node Name') 
	panel.addSingleLinelnput('Search:', ") 
	search = panel.show() 
	if search:
		searchString = panel.value('Search:') 
		selectByNodeName(searchString.replace('*', '.+').replace('_', '\_')) 
