"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Address = void 0;
var department_1 = require("./department");
var district_1 = require("./district");
var province_1 = require("./province");
var Address = /** @class */ (function () {
    function Address() {
        this.AddressId = 0;
        this.DepartmentId = 0;
        this.ProvinceId = 0;
        this.DistrictId = 0;
        this.Department = new department_1.Department();
        this.Province = new province_1.Province();
        this.District = new district_1.District();
    }
    return Address;
}());
exports.Address = Address;
//# sourceMappingURL=address.js.map
