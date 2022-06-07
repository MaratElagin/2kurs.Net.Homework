import React from 'react';
import {FieldErrors, UseFormRegister, ValidationRule} from "react-hook-form";
import {FormInputs} from "../../Dto/FormInputs";

interface TextInputProps {
    name: 'lastName' | 'firstName' | 'middleName' |'passportNumber' | 'passportSeries' | 'creditSum';
    placeHolder: string;
    register: UseFormRegister<FormInputs>;
    errors: FieldErrors<FormInputs>;
    maxLength?: ValidationRule<number> | undefined;
    required: string;
    pattern?: ValidationRule<RegExp> | undefined
}

const TextInput: React.FC<TextInputProps> = ({
                                                 name,
                                                 placeHolder, register, errors,
                                                 maxLength, required, pattern= undefined
                                             }) => {
    return (
        <div className={"mb-2"}>
            <input className={"w-100 my_text_input"}
                {...register(name, {
                    required: required,
                    maxLength: maxLength,
                    pattern:pattern
                })} type="text" placeholder={placeHolder}/>
            {errors[name] && <div style={{color: 'red'}}>{errors[name]?.message}</div>}
        </div>
    );
};

export default TextInput;