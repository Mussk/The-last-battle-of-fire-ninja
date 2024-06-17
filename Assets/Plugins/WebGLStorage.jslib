mergeInto(LibraryManager.library, {
    SaveData: function(keyPtr, valuePtr) {
        var key = UTF8ToString(keyPtr);
        var value = UTF8ToString(valuePtr);
        localStorage.setItem(key, value);
    },
    LoadData: function(keyPtr) {
        var key = UTF8ToString(keyPtr);
        var value = localStorage.getItem(key);
        if (value) {
            var bufferSize = lengthBytesUTF8(value) + 1;
            var buffer = Module._malloc(bufferSize);
            stringToUTF8(value, buffer, bufferSize);
            return buffer;
        }
        return 0;
    },

    EraseData: function(keyPtr) {
        var key = UTF8ToString(keyPtr);
        localStorage.removeItem(key);
    }

});