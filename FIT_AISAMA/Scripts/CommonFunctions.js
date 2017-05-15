var commonFunctionHelper = {
    capitalizeText: function(text) {
        return text.toLowerCase().replace(/([ёйцукенгшщзхъфывапролджэячсмитьбю]|\w)+/g,function(s){return s.charAt(0).toUpperCase() + s.substr(1).toLowerCase();});
    }
}