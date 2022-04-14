import nuke

def deselectAllNodes(): 

	""" Deselects an nodes in current session of Nuke 
	""" 

	for node in nuke.allNodes(): 
		node['selected'] .setValue(False) 
