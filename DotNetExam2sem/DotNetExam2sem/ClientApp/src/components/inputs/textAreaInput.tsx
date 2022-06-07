import React from 'react';
import {FieldErrors, UseFormRegister, ValidationRule} from "react-hook-form";
import {FormInputs} from "../../Dto/FormInputs";

interface TextInputProps {
    name: 'passportAddress' | 'passportAgency'
    placeHolder: string;
    register: UseFormRegister<FormInputs>;
    errors: FieldErrors<FormInputs>;
    maxLength?: ValidationRule<number> | undefined;
    required: string;
}

const TextAreaInput: React.FC<TextInputProps> = ({
                                                 name,
                                                 placeHolder, register, errors,
                                                 maxLength, required
                                             }) => {
    return (
        <div className={"mb-2 w-100 my_textarea"}>
            <textarea
                {...register(name, {
                    required: required,
                    maxLength: maxLength,
                })} placeholder={placeHolder}/>
            {errors[name] && <div style={{color: 'red'}}>{errors[name]?.message}</div>}
        </div>
    );
};

export default TextAreaInput;