import React, { useState, useEffect, useCallback } from 'react';
import './buyer.scss';
import { Form, SimpleItem, ButtonItem } from 'devextreme-react/form';
import ODataStore from 'devextreme/data/odata/store';
import { useParams } from 'react-router-dom';
import { useNavigate } from "react-router-dom";

export default () => {
    const { recId } = useParams();
    const [buyer, setBuyer] = useState(null);
    const navigate = useNavigate();

    const store = new ODataStore({
        url: `odata/buyers(${recId})`,
        key: 'recId',
        keyType: 'Int32',
        version: 4,

        onLoaded: function (data) {
            setBuyer(data);
        }
    });

    useEffect(() => {
        if (recId !== undefined)
            store.load();
    }, [recId]);

    const submitButtonOptions = {
        text: "Сохранить",
        useSubmitBehavior: true
    };

    const handleSubmit = useCallback((e) => {
        const url = recId === undefined ? 'api/buyers/add' : `api/buyers/edit/${recId}`;

        const body = JSON.stringify(buyer);

        fetch(url, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: body
        })
            .then(response => {
                console.debug(response);

                // если это была новая запись то уйдем назад в грид
                if (recId === undefined) {
                    navigate('/buyers')
                }
            })
            .catch(err => {
                console.error(err);
            });

        alert('Сохранено');

        e.preventDefault();

    }, [buyer]);

    const handleFieldDataChanged = useCallback((e) => {
        const updatedField = e.dataField;

        if (updatedField == 'registrationDate' || updatedField === 'birthDate') {
            e.value.setHours(12, 0, 0, 0)
        }

        const formData = e.component.option('formData');

        setBuyer(formData);
    });

    return (<React.Fragment>
        <h2 className={'content-block'}>Покупатель</h2>
        <div className={'content-block'}>
            <div className={'dx-card responsive-paddings'}>
                Профиль покупателя {recId}
            </div>

            <div className={'dx-card responsive-paddings'}>
                <form onSubmit={handleSubmit}>
                    <Form onFieldDataChanged={handleFieldDataChanged }
                        formData={buyer}
                        id={'form'}
                        labelLocation={'top'}
                        colCountByScreen={colCountByScreen}
                    >
                        <SimpleItem dataField="firstName" />
                        <SimpleItem dataField="secondName" />
                        <SimpleItem dataField="middleName" />
                        <SimpleItem dataField="sex" editorType='dxSelectBox' editorOptions={{
                            dataSource: sexRus,
                            displayExpr: "name",
                            valueExpr: "value",
                        }}>
                        </SimpleItem>
                        <SimpleItem dataField="birthDate" editorType='dxDateBox'/>
                        <SimpleItem dataField="registrationDate" editorType='dxDateBox' />
                        <SimpleItem dataField="isAgree" editorType='dxCheckBox' />

                        <ButtonItem buttonOptions={submitButtonOptions} />

                    </Form>
                </form>
            </div>
        </div>
    </React.Fragment>);
};

const colCountByScreen = {
    xs: 1,
    sm: 2,
    md: 3,
    lg: 4
};

const sexRus = [
    { name: 'Муж', value: 'M' },
    { name: 'Жен', value: 'F' },
];
