"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Person = void 0;
var address_1 = require("./address");
var Person = /** @class */ (function () {
    function Person() {
        this.Id = "";
        this.Title = "";
        this.Email = "";
        this.FirstName = "";
        this.LastName = "";
        this.SurName = "";
        this.FullName = "";
        this.IdentificationNumber = "";
        this.Phone = "";
        this.Address = new address_1.Address();
    }
    return Person;
}());
exports.Person = Person;
//# sourceMappingURL=person.js.map