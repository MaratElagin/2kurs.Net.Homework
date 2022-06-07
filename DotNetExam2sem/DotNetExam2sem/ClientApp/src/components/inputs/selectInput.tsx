import React from 'react';
import {Control, Controller, FieldErrors, UseFormRegister, ValidationRule} from "react-hook-form";
import {FormInputs} from "../../Dto/FormInputs";
import ReactSelect from "react-select";
import {IOption} from "../Selects/IOption";

interface SelectInputProps {
    name: any;
    placeHolder: string;
    required: string;
    control: Control<FormInputs, any>
    options: IOption[]
}

const getValue = (options:IOption[], value: string | boolean) =>
    value ? options.find((option) => option.value === value) : "";

const SelectInput: React.FC<SelectInputProps> = ({
                                                   name,
                                                   placeHolder, required, control, options
                                               }) => {
    return (
        <div className={"mb-2"}>
            <Controller control={control} name={name}
                        rules={{
                            required: required
                        }}
                        render={({field: {onChange, value}, fieldState: {error}}) => (
                            <>
                                <ReactSelect className={"mt-2 mb-2"}
                                             placeholder={placeHolder}
                                             options={options}
                                             value={getValue(options, value)}
                                             onChange={(newValue) => onChange((newValue as IOption).value)}
                                />
                                {error && <div style={{color: 'red'}}>{error.message}</div>}
                            </>
                        )}
            />
        </div>
    );
};

export default SelectInput;