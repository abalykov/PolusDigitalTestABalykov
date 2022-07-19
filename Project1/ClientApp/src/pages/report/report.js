import React, { useCallback } from 'react';
import './report.scss';
import { Button } from 'devextreme-react/button';

export default () => {

    const onClick = useCallback((e) => {
        const url = 'api/reports/somereport/';

        fetch(url, {
            method: 'GET',
            headers: { 'Content-Type': 'application/json' },
        })
            .then((response) => response.blob())
            .then((blob) => {
                const url = window.URL.createObjectURL(
                    new Blob([blob]),
                );
                const link = document.createElement('a');
                link.href = url;
                link.setAttribute(
                    'download',
                    `report.txt`,
                );

                document.body.appendChild(link);

                link.click();

                link.parentNode.removeChild(link);
            });
    });


    return (
        <React.Fragment>
            <h2 className={'content-block'}>Report</h2>
            <div className={'content-block'}>
                <div className={'dx-card responsive-paddings'}>
                    Выгрузка некоторого отчета
                </div>

                <div className={'dx-card responsive-paddings'}>
                    <Button
                        width={120}
                        text="Выгрузить"
                        type="normal"
                        stylingMode="contained"
                        onClick={onClick}
                    />
                </div>
            </div>
        </React.Fragment>
    )
};
