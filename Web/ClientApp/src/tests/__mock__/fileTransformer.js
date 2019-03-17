// fileTransformer.js
// const path = require('path');
import path from 'path';

module.exports = {
  process(src, filename, config, options) {
    return 'module.exports = ' + JSON.stringify(path.basename(filename)) + ';';
  },
};
