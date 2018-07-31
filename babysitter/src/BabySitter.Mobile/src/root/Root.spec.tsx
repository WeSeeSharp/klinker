import * as React from "react";
import {mount} from "enzyme";
import {Root} from "./Root";


describe('Root', () => {
    it('should say hello', () => {
        const root = mount(<Root />);
        expect(root.text()).toContain('Hello');
    })
})