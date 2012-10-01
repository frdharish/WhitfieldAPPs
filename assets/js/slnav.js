var selfnav;
function LTwoNavBar()
{
	selfnav = this;
	this.mouseState = 'off';
	this.interval = null;
	this.mNode = null;
	this.cNode = null;
	this.initializing = false;
	this.init();
}

LTwoNavBar.prototype.init = function() // this will poll the bar until it finds the node
{
	this.mNode = this.getElement('n2I');
	var selects;
	if(this.mNode == null && this.initializing == false)
	{
		this.interval = setInterval('selfnav.init()', 200);
	}
	else
	{
		this.cNode = this.getElement('dcm');
		if(this.cNode != null)
		{
			clearInterval(this.interval);
			this.mNode.onmouseout = function()
			{
				selfnav.mouseState = 'off';
				setTimeout('selfnav.checkMouse()',1000);
			}
			this.mNode.onmouseover = function() 
			{
				selfnav.mouseState = 'on';
				selfnav.mNode.style.color = '#FFF';
				selfnav.cNode.style.display = 'block';
				selects = document.getElementsByTagName('select');
				for(var i=0; i<selects.length; i++)
				{
					if(selects[i].className == 'tablesm')
					{
						selects[i].style.visibility = 'hidden';
					}
				}
			}
			this.cNode.onmouseout = this.mNode.onmouseout;
			this.cNode.onmouseover = this.mNode.onmouseover;
		}
	}
	this.initializing = true;
}

LTwoNavBar.prototype.checkMouse = function()
{
	if(selfnav.mouseState == 'off')
	{
		selfnav.mNode.style.color = '#CCC';
		selfnav.cNode.style.display = 'none';
		selects = document.getElementsByTagName('select');
		for(var i=0; i<selects.length; i++)
		{
			if(selects[i].className == 'tablesm')
			{
				selects[i].style.visibility = 'visible';
			}
		}
	}
}

LTwoNavBar.prototype.getElement = function(el)
{
	if(document.getElementById(el))
	{
		return document.getElementById(el);
	}
	else if(!document.getElementById && document.all[el])
	{
		return document.all[el];
	}
	else
	{
		return null;
	}
}
var lTwoNav = new LTwoNavBar(); 
