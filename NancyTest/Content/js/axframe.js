    function showInfo(info) {
        document.getElementById("ax_info").innerText = info;
    }

    function detectActiveX() {
        try {
            if (!bowser.msie) {
                alert("not supported browser: " + bowser.name);
                return false;
            }
            var obj = new ActiveXObject('StillWaiting.AxEmbeddedPanel');
            // alert("activex control installed")
            return true;
        }
        catch (ex) {
            alert("activex control not installed")
            return false;
        }
    }
    function addAxElement() {
        try {
            var node = document.createElement("OBJECT");
            node.id = "DemoActiveX";
            node.classid = "clsid:DEDF3A2C-5D5F-411A-A7E0-589870C995B9";
            node.codebase = "./content/cab/AxDemo.cab";
            document.getElementById("axContainer").appendChild(node);
        }
        catch (ex) {
            //alert("Error in addAxElement: " + ex.Description);
            showInfo("Error in addAxElement: " + ex.Description)
        }
    }
